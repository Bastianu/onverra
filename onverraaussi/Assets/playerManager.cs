using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public Ship myShip;
    // Start is called before the first frame update
    void Start()
    {
        //check db
        //attach ship + bonus + etc
        myShip = new Ship();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
