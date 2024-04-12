using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleModifier : MonoBehaviour
{
    // Start is called before the first frame update
    ParticleSystem particleSystem;
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    void OnCollisionEnter(Collision other) {
        Debug.Log("Collided with: " + other.collider.gameObject.name); // Log the name of the collided object
        if (other.collider.tag == "Player") {
            Debug.Log("Collision with specific tag detected!");
            var mainModule = particleSystem.main;
            mainModule.startColor = new ParticleSystem.MinMaxGradient(Color.red);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
