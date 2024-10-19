using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat
{
    public GameObject boat;
    public Role[] onBoat;
    public bool isRight;
    public int priestCount, devilCount;

    public Boat(Vector3 position) {
        boat = GameObject.Instantiate(Resources.Load("Prefabs/Boat", typeof(GameObject))) as GameObject;
        boat.name = "boat";
        boat.transform.position = position;

        onBoat = new Role[2];
        isRight = false;
        priestCount = devilCount = 0;

        boat.AddComponent<BoxCollider>();
        boat.AddComponent<Click>();
        
    }
}
