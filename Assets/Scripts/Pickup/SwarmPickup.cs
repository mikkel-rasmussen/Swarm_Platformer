using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmPickup : PickupComponentBase
{
    [Range(50, 200)]
    public int numParticles = 150;

    private void Start()
    {
        var main = GetComponent<ParticleSystem>().main;
        main.maxParticles = numParticles;
    }

    public override IPickupComponent Pickup()
    {
        Use(GameObject.FindObjectOfType<PlayerPowerup>());
        return null;
    }

    public override void Use(PlayerPowerup _powerupComponent)
    {
        var main = _powerupComponent.GetComponent<ParticleSystem>().main;
        main.maxParticles += numParticles;
        Destroy(this.gameObject);
    }
}
