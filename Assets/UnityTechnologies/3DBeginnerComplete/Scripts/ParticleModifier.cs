using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleModifier : MonoBehaviour
{
    // Start is called before the first frame update
    ParticleSystem particleSystem;
    Rigidbody rb;
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        // Get the particles from the particle system
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
        int particleCount = particleSystem.GetParticles(particles);

        // Change only the particles that are alive
        for (int i = 0; i < particleCount; i++)
        {
            // Calculate distance between this object and the target rigidbody
            float distance = Vector3.Distance(particles[i].position, rb.position);
            float normalizedDistance = Mathf.Clamp01(distance / 80f);

            float currentY = particles[i].position.y;
            float targetY = 1.0f;
            float noise = Random.Range(-0.1f, 0.1f);
            float newY = Mathf.Lerp(currentY, targetY + noise, normalizedDistance);

            // Update the particle's position
            particles[i].position = new Vector3(particles[i].position.x, newY, particles[i].position.z);
        }

        // Apply the modified positions to the particle system
        particleSystem.SetParticles(particles, particleCount);
    }
}
