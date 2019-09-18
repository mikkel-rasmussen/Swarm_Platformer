using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTimeLimit : MonoBehaviour
{
    private TMPro.TMP_Text text;

    private int timeLimit = 0;
    private void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }
    public void SetLimit(int duration)
    {
        timeLimit = duration;
    }

    // Update is called once per frame
    void Update()
    {
        var seconds = timeLimit % 60;
    }
}
