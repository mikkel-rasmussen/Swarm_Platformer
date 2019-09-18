using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickupComponent
{
    IPickupComponent Pickup();
    void Use(PlayerPowerup _powerupController);
}
