using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int moveSpeedMultiplier = 2;

    [SerializeField] private FiredParticles firedParticles;

    private enum PlayerDirection
    {
        Left,
        Right
    }

    private PlayerDirection eDirection = PlayerDirection.Right;

    // Start is called before the first frame update
    void Start()
    {
        
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

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            FireParticles();
        }
    }

    private void FireParticles()
    {
        FiredParticles FP = Instantiate<FiredParticles>(firedParticles, transform.position, transform.rotation);

        var ps = GetComponent<ParticleSystem>();
        var main = ps.main;
        main.maxParticles -= 300;

        if (main.maxParticles <= 0)
        {
            Debug.Log("Dead");
            return;
        }

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
        FP.particlesUsedAmount = 300;
    }
}
