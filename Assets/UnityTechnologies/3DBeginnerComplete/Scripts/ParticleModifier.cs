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

    void OnPartileCollision(GameObject other) {
        Debug.Log("Collided with: " + other.name); // Log the name of the collided object
        if (other.tag == "Player") {
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
