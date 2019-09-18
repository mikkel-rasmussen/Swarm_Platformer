using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour
{
    [SerializeField] Transform PlayerStart = null;
    [SerializeField] Transform PlayerEnd = null;

    [SerializeField] Transform PlayerCharacterRef = null;
    private Transform playerCharacter = null;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = Instantiate<Transform>(PlayerCharacterRef, PlayerStart.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if ((playerCharacter.position - PlayerEnd.position).sqrMagnitude < 15)
        {
            Debug.Log("Game Ended");
        }
    }
}
