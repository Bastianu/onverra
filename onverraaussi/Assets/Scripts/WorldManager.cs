using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    List<GameObject> planets;
    List<GameObject> suns;

    public float averagePlanetSize = 40;
    public float averagePlanetNumber = 3;

    // Start is called before the first frame update
    void Start()
    {
        planets = new List<GameObject>();
        for(int i = 0; i < averagePlanetNumber; i++)
        {
            GameObject planet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            planet.transform.localScale = Vector3.one * averagePlanetSize;
            planet.name = "Planet" + i;
            planet.AddComponent<PlanetEnter>();
            planet.GetComponent<SphereCollider>().isTrigger = true;
            planet.AddComponent<planetRotation>().Sun = GameObject.Find("Sun").transform;
            planet.transform.position = new Vector3(200 * i, 70, 0);

            planets.Add(planet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
