using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship
{
    public float health { get; set; } = 1000;
    public float speed { get; set; } = 10;
    public float armor { get; set; } = 1000;

    public int maniability { get; set; } = 50;

    public float exp { get; set; } = 0;

    public int level { get; set; } = 0;

    //public List<Ressource> levelUpRessources;

    public List<Feature> Features { get; set; } = new List<Feature>();

   //public Texture3D texture = Texture.Instantiate()

    //private Material material = Material.Create()

}
