using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerup : MonoBehaviour
{
    IPickupComponent pickupItem = null;

    private void Update()
    {
        if (pickupItem != null && Input.GetKeyDown(KeyCode.LeftControl))
        {
            pickupItem.Use(this);
            pickupItem = null;
        }
    }

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
