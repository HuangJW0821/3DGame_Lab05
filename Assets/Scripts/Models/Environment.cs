using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment{
    public GameObject environment;

    public Environment(Vector3 position) {
        environment = GameObject.Instantiate(Resources.Load("Prefabs/Environment", typeof(GameObject))) as GameObject;
        environment.transform.position = position;
    }
}