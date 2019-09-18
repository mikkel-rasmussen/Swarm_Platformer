using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private GameObject statsObject = null;
    private TrackableStats stats = null;

    private void Awake()
    {
        stats = GameObject.FindObjectOfType<TrackableStats>();

        statsObject = new GameObject("NewStats");
        statsObject.AddComponent<TrackableStats>(stats);

        Destroy(stats.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
