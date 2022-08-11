using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarParticlesController : MonoBehaviour
{
    ParticleSystem particleSystem;
    Rigidbody rigidbody;

    bool isParticleActive;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        rigidbody = transform.parent.GetComponent<Rigidbody>();

        isParticleActive = false ;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!particleSystem.isPlaying)
        {
            if (rigidbody.velocity.magnitude > 0.4)
                particleSystem.Play();
        }
        else
        {
            if (rigidbody.velocity.magnitude < 0.4 || transform.position.y<.4f)
                particleSystem.Stop();
        }


    }

}
