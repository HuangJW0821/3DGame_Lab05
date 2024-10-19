using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction {
    public CCActionManager actionManager;
    public EnvironmentCtrl environmentCtrl;
    public ShoreCtrl leftShoreController, rightShoreController;
    // public River river;
    public BoatCtrl boatController;
    public RoleCtrl[] roleControllers;
    public bool isRunning;
    public float time;

    public void JudgeCallback(bool isRunning, string message){   
        this.gameObject.GetComponent<UserGUI>().gameMessage = message;
        this.gameObject.GetComponent<UserGUI>().time = (int)time;
        this.isRunning = isRunning;
    }
    public void LoadResources() {
        // environment
        environmentCtrl = new EnvironmentCtrl();
        environmentCtrl.CreateEnvironment(Position.env_position);

        // role
        roleControllers = new RoleCtrl[6];
        for (int i = 0; i < 6; ++i) {
            roleControllers[i] = new RoleCtrl();
            roleControllers[i].CreateRole(Position.role_shore[i], i < 3 ? true : false, i);
        }

        // shore
        leftShoreController = new ShoreCtrl();
        leftShoreController.CreateShore(Position.left_shore);
        leftShoreController.GetShore().shore.name = "left_shore";
        
        rightShoreController = new ShoreCtrl();
        rightShoreController.CreateShore(Position.right_shore);
        rightShoreController.GetShore().shore.name = "right_shore";

        // add Role on left shore 
        foreach (RoleCtrl roleController in roleControllers)
        {
            roleController.GetRoleModel().role.transform.localPosition = leftShoreController.AddRole(roleController.GetRoleModel());
        }

        // boat
        boatController = new BoatCtrl();
        boatController.CreateBoat(Position.left_boat);

        isRunning = true;
        time = 90;
    }

    public void MoveBoat() {
        if (isRunning == false || actionManager.IsMoving()) return;
        Vector3 destination = boatController.GetBoatModel().isRight ? Position.left_boat : Position.right_boat;
        actionManager.MoveBoat(boatController.GetBoatModel().boat, destination, 15);

        boatController.GetBoatModel().isRight = !boatController.GetBoatModel().isRight;
    
    }

    public void MoveRole(Role roleModel) {
        if (isRunning == false || actionManager.IsMoving()) return;
        
        Vector3 destination, mid_destination;
        
        if (roleModel.inBoat){
            if (boatController.GetBoatModel().isRight)
                destination = rightShoreController.AddRole(roleModel);
            else
                destination = leftShoreController.AddRole(roleModel);
            
            if (roleModel.role.transform.localPosition.y > destination.y)
                mid_destination = new Vector3(destination.x, roleModel.role.transform.localPosition.y, destination.z);
            else
                mid_destination = new Vector3(roleModel.role.transform.localPosition.x, destination.y, destination.z);
            
            actionManager.MoveRole(roleModel.role, mid_destination, destination, 80);
            roleModel.onRight = boatController.GetBoatModel().isRight;
            boatController.RemoveRole(roleModel);
        }else{
            
            if (boatController.GetBoatModel().isRight == roleModel.onRight){
                if (roleModel.onRight)
                    rightShoreController.RemoveRole(roleModel);
                else
                    leftShoreController.RemoveRole(roleModel);
                
                destination = boatController.AddRole(roleModel);
                
                if (roleModel.role.transform.localPosition.y > destination.y)
                    mid_destination = new Vector3(destination.x, roleModel.role.transform.localPosition.y, destination.z);
                else
                    mid_destination = new Vector3(roleModel.role.transform.localPosition.x, destination.y, destination.z);
                actionManager.MoveRole(roleModel.role, mid_destination, destination, 20);
            }
        }
    }

    public void Check() {}

    public void ResetGame() {
    if(environmentCtrl.GetEnvironment() != null)
        Destroy(environmentCtrl.GetEnvironment().environment);

    if(leftShoreController.GetShore() != null)
        Destroy(leftShoreController.GetShore().shore);
    if(rightShoreController.GetShore() != null)
        Destroy(rightShoreController.GetShore().shore);

    foreach (var roleController in roleControllers) {
        if (roleController.GetRoleModel().role != null) {
            Destroy(roleController.GetRoleModel().role);
        }
    }
    
    if (boatController.GetBoatModel().boat != null) {
        Destroy(boatController.GetBoatModel().boat);
    }

    // time = 90;
    // this.gameObject.GetComponent<UserGUI>().time = (int)time;
    // isRunning = true;

    LoadResources();
    
    this.gameObject.GetComponent<JudgeController>().ResetJudge();
    // this.gameObject.GetComponent<UserGUI>().gameMessage = "Game Reset!";
}


    void Awake() {
        SSDirector.GetInstance().CurrentSceneController = this;
        LoadResources();
        this.gameObject.AddComponent<UserGUI>();
        this.gameObject.AddComponent<CCActionManager>();
        this.gameObject.AddComponent<JudgeController>();
    }

    void Update() {
        if (isRunning){   
            if((int)time >= 0) time -= Time.deltaTime;
            this.gameObject.GetComponent<UserGUI>().time = (int)time;
        }
    }
}