using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerup : MonoBehaviour
{
    IPickupComponent pickupItem = null;

    private void Update()
    {
        if (pickupItem != null && Input.GetKeyDown(KeyCode.Space))
        {
            pickupItem.Use(this);
            pickupItem = null;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (pickupItem != null) { return; }

    //    if (collision.gameObject.GetComponent<IPickupComponent>() != null)
    //    {
    //        pickupItem = collision.gameObject.GetComponent<IPickupComponent>().Pickup();
    //        Destroy(collision.gameObject.GetComponent<Renderer>());
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (pickupItem != null) { return; }

        if (other.gameObject.GetComponent<IPickupComponent>() != null)
        {
            pickupItem = other.gameObject.GetComponent<IPickupComponent>().Pickup();
            Destroy(other.gameObject.GetComponent<Renderer>());
        }
    }
}
