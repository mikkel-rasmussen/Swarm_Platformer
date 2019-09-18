using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int moveSpeedMultiplier = 2;

    [SerializeField] private FiredParticles firedParticles;
    [SerializeField] private int particlesUsedFiringSwarm = 100;

    private Camera camera;
    private float minimalFov;
    private float maxFov = 180;

    FadeOutUI no_swarm_cg;

    private void Awake()
    {
        no_swarm_cg = GameObject.Find("no_swarm_left").GetComponent<FadeOutUI>();
    }

    private enum PlayerDirection
    {
        Left,
        Right
    }

    private PlayerDirection eDirection = PlayerDirection.Right;

    // Start is called before the first frame update
    void Start()
    {
        camera = transform.Find("Main Camera").GetComponent<Camera>();
        minimalFov = camera.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        float xDir = 0;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            xDir = Time.deltaTime * moveSpeedMultiplier;
            eDirection = PlayerDirection.Right;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            xDir = Time.deltaTime * -moveSpeedMultiplier;
            eDirection = PlayerDirection.Left;
        }

        transform.Translate(xDir, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireParticles();
        }
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            var fov = camera.fieldOfView;
            fov += 5;
            fov = Mathf.Clamp(fov, minimalFov, maxFov);
            camera.fieldOfView = fov;
        }


        if (!Input.GetKey(KeyCode.LeftShift))
        {
            var fov = camera.fieldOfView;
            fov -= 5;
            fov = Mathf.Clamp(fov, minimalFov, maxFov);
            camera.fieldOfView = fov;
        }
    }

    private void FireParticles()
    {
        var ps = GetComponent<ParticleSystem>();
        var main = ps.main;
        if (main.maxParticles > particlesUsedFiringSwarm)
        {
            FiredParticles FP = Instantiate<FiredParticles>(firedParticles, transform.position, transform.rotation);

            main.maxParticles -= particlesUsedFiringSwarm;

            SphereCollider col = FP.gameObject.AddComponent<SphereCollider>(this.GetComponent<SphereCollider>());

            col.isTrigger = true;

            Vector3 target = transform.position;

            if (eDirection == PlayerDirection.Right)
            {
                target += Vector3.right * 30;
            }
            else
            {
                target += Vector3.left * 30;
            }

            FP.playerTransform = this.transform;
            FP.target = target;
            FP.particlesUsedAmount = particlesUsedFiringSwarm;
        }
        else
        {
            no_swarm_cg.FadeOut();
        }
    }
}
