using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCRotateAction : SSAction{
    //目的地
    public Vector3 eulers;
    //速度
    public Space relativeTo;
    private Vector3 destAngles;

    private CCRotateAction(){}

    //生产函数(工厂模式)
    public static CCRotateAction GetSSAction(Vector3 eulers, Space relativeTo = Space.Self){
        CCRotateAction action = ScriptableObject.CreateInstance<CCRotateAction>();
        action.eulers = eulers;
        action.relativeTo = relativeTo;
        return action;
    }

    // Start is called before the first frame update
    public override void Start(){
        // this.destAngles = this.transform.eulerAngles + this.eulers;
        // this.destAngles[1] = this.destAngles[1] % 360;
        // Debug.LogFormat("{0} -> {1}", this.transform.eulerAngles, this.destAngles);
        // this.transform.Rotate(this.eulers, this.relativeTo);
    }

    // Update is called once per frame
    public override void Update(){
        // if (this.gameObject == null || this.transform.eulerAngles == this.destAngles){
        //     this.destroy = true;
        //     this.callback.SSActionEvent(this);
        //     return;
        // }
        // return;
        // this.transform.Rotate(this.eulers[0], this.eulers[1]*Time.deltaTime, this.eulers[2], this.relativeTo);
    }
}