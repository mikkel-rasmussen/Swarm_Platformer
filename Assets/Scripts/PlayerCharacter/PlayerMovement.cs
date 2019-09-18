using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int moveSpeedMultiplier = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xDir = 0;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow))
        {
            xDir = Time.deltaTime * moveSpeedMultiplier;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow))
        {
            xDir = Time.deltaTime * -moveSpeedMultiplier;
        }

        transform.Translate(xDir, 0, 0);
    }
}
