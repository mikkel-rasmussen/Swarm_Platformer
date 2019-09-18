using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    private GameObject statsObject = null;
    private TrackableStats stats = null;

    public Image backgroundImage;
    public Button restart;
    public Image headline;

    public Sprite winImg;
    public Sprite loseImg;

    private void Awake()
    {
        stats = GameObject.FindObjectOfType<TrackableStats>();

        statsObject = new GameObject("NewStats");
        statsObject.AddComponent<TrackableStats>(stats);

        Destroy(stats.gameObject);

        stats = statsObject.GetComponent<TrackableStats>();
    }

    private void Start()
    {
        if (stats.winState == 1)
        {
            // lose
            backgroundImage.color = Color.black;
            ColorBlock cb = restart.colors;
            cb.normalColor = Color.white;
            cb.highlightedColor = Color.grey;
            cb.pressedColor = Color.white;

            restart.colors = cb;
            headline.sprite = loseImg;
        }
        else
        {
            // win
            backgroundImage.color = Color.white;
            ColorBlock cb = restart.colors;
            cb.normalColor = Color.black;
            cb.highlightedColor = Color.grey;
            cb.pressedColor = Color.white;

            restart.colors = cb;
            headline.sprite = winImg;
        }

        restart.onClick.AddListener(() => SceneManager.LoadScene("Game"));
    }
}
