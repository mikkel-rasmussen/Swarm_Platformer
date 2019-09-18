using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;

public class MazeReader : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        var maze = ReadMaze("Assets/Resources/maze_bitmap.bmp", "Prefabs/Cube");
        maze.Activate();
    }

    Maze ReadMaze(string bitmap, string brick)
    {
        var cubePrefab = Resources.Load(brick) as GameObject;
        var loaded = new BMPLoader();
        var bmp = loaded.LoadBMP(bitmap);
        var texture = bmp.ToTexture2D();
        var width = texture.width;
        var height = texture.height;
        var row = 0;
        var objects = new List<GameObject>();
        for (var i = 0; i < bmp.imageData.Length; i += width)
        {
            row += 1;
            for (int j = 0; j < width; j++)
            {
                var color = bmp.imageData[i + j];
                if (color.r == 0 && color.g == 0 && color.b == 0)
                {
                    var cube = Instantiate(cubePrefab) as GameObject;
                    var collider = cube.GetComponent<Collider>();
                    var bounds = collider.bounds;
                    var position = new Vector3(j * bounds.size.x, row * bounds.size.y, 0);
                    cube.transform.position = position;
                    objects.Add(cube);
                }
            }
        }
        return new Maze(width, height, objects);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class Maze
    {
        public IList<GameObject> Objects { get; set; }
        public int Width { get; }
        public int Height { get; }

        public Maze(int width, int height, IList<GameObject> objects)
        {
            Objects = objects;
            Width = width;
            Height = height;
        }

        public void Activate()
        {
            foreach (var gameObject in Objects)
            {
                gameObject.SetActive(true);
            }
        }

        public void Deactivate()
        {
            foreach (var gameObject in Objects)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
