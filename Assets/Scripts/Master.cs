using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Master : MonoBehaviour
{
    public int timeLimitInSecs = 240;
    private float timePassed = 0f;

    [SerializeField] Transform PlayerStart = null;
    [SerializeField] Transform PlayerEnd = null;

    [SerializeField] Transform PlayerCharacterRef = null;
    private Transform playerCharacter = null;

    [SerializeField] TMPro.TMP_Text timeLimitText = null;

    private TrackableStats stats;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = Instantiate<Transform>(PlayerCharacterRef, PlayerStart.position, Quaternion.identity);
        GameObject statsgo  = new GameObject("GameStats");
        stats = statsgo.AddComponent<TrackableStats>();
        DontDestroyOnLoad(statsgo);
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        timeLimitText.text = (timeLimitInSecs - (int)timePassed % 60).ToString();
        if ((playerCharacter.position - PlayerEnd.position).sqrMagnitude < 25 || timePassed >= timeLimitInSecs)
        if ((playerCharacter.position - PlayerEnd.position).sqrMagnitude < 15)
        {
            SceneManager.LoadScene("EndGame");
        }
        else if (timePassed >= timeLimitInSecs)
        {
            stats.winState = 1;
            SceneManager.LoadScene("EndGame");
        }
    }
}
