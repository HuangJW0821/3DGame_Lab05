using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCtrl{
    Environment environmentModel;

    public void CreateEnvironment(Vector3 position){
        if(environmentModel == null)
            environmentModel = new Environment(position);
    }

    public Environment GetEnvironment() { return environmentModel;}
}