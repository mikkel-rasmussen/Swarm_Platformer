using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupComponentBase : MonoBehaviour, IPickupComponent
{
    public IPickupComponent Pickup()
    {
        return this;
    }

    public abstract void Use(PlayerPowerup _poweruoComponent);
}
