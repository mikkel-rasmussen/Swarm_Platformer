using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningPickupComponent : PickupComponentBase
{
    private float powerupDuration = 5f;


    public override void Use(PlayerPowerup _poweruoComponent)
    {
        Debug.Log("Item used");
        ParticleSystem ps = _poweruoComponent.GetComponent<ParticleSystem>();
        var trails = ps.trails;

        trails.enabled = true;

        StartCoroutine(SwitchOff(ps));
    }

    private IEnumerator SwitchOff(ParticleSystem _ps)
    {
        float current = 0f;

        while (current < 1f)
        {
            current += Time.deltaTime / powerupDuration;

            yield return null;
        }
        var trails = _ps.trails;
        trails.enabled = false;

        Destroy(this.gameObject);
    }
}
