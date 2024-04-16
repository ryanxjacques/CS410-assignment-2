using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    public Transform player;
    public GameObject play;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        // checks to see if the player collides with the object
        if(other.transform == player)
        {
            // gets position of player in a really roundabout way
            var playerObject = play;
            Vector3 pos = playerObject.transform.position;
            float hor = pos.x;
            float ver = pos.z;

            // uses dot product to check that the player is in a certain corner of the box collider
            if((1.0f*hor)+(0.0f*ver) < -18.5f){
                
                // teleports the player above the map (not sure why they don't fall, since gravity is
                // enabled, but it doesn't make too much of a difference)
                player.transform.position = new Vector3(13.0f,15.0f,1.5f);
            }
        }
    }
}
