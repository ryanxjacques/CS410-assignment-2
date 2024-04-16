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
            var playerObject = play;
            Vector3 pos = playerObject.transform.position;
            float hor = pos.x;
            float ver = pos.z;
            if((1.0f*hor)+(0.0f*ver) < -18.5f){
                player.transform.position = new Vector3(13.0f,15.0f,1.5f);
            }
            //player.transform.position = new Vector3(13.0f,15.0f,1.5f);
        }
    }
}
