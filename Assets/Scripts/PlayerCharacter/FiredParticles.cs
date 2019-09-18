using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiredParticles : MonoBehaviour
{
    public Vector3 target;
    public int particlesUsedAmount = 10;
    public Transform playerTransform = null;

    private float movementSpeed = 2f;
    private bool isLatchedOn = false;
    private bool targetReached = false;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        var ps = gameObject.GetComponent<ParticleSystem>();
        var main = ps.main;
        main.maxParticles = particlesUsedAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLatchedOn) { return; }

        if (!targetReached)
        {
            if ((transform.position - target).sqrMagnitude < 10)
            {
                targetReached = true;
            }
        }
        else
        {
            target = playerTransform.position;

            if ((transform.position - target).sqrMagnitude < 10)
            {
                var main = playerTransform.GetComponent<ParticleSystem>().main;
                main.maxParticles += particlesUsedAmount;
                Destroy(this.gameObject);
            }
        }

        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * movementSpeed);
    }

    IEnumerator LatchOn(Vector3 objPos)
    {
        float duration = 0.5f;
        float current = 0f;

        while (current < 1f)
        {
            current += Time.deltaTime * duration;

            transform.position = Vector3.Lerp(transform.position, objPos, current);

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Obstacle")))
        {
            Debug.Log("Latching On");
            other.GetComponent<Obstacle>().Dissolve();

            if (!isLatchedOn)
            {
                StartCoroutine(LatchOn(other.transform.position));
                other.GetComponent<Obstacle>().callback = () => Destroy(gameObject);

                isLatchedOn = true;
            }
            
        }
    }
}
