using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetEnter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " triggered " + this.name);
        if(other.name == "Vaisseau")
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            GameObject.Find("Player").GetComponent<PlayerMovement>()._Velocity = 0;
        }
    }
}
