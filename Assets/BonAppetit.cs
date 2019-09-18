using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Destroyer))]
public class BonAppetit : MonoBehaviour
{
    [SerializeField]private Destroyer destroyer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider collider)
    {
        destroyer.Destroy();
    }
}
