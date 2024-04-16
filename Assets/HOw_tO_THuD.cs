using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HOw_tO_THuD : MonoBehaviour
{
    public AudioSource thuds;
    public Renderer rend;
    public AudioSource duths;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("he touchin me");
        thuds.Play();
        rend.enabled = true;
    }
    void OnTriggerExit(Collider other)
    {
        rend.enabled = false;
    }
}
