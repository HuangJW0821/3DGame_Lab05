using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position{
    // static position
    public static Vector3 env_position = new Vector3(0, 0, 0);
    public static Vector3 left_shore = new Vector3(4f, 0.45f, 6);
    public static Vector3 right_shore = new Vector3(-10f, 0.45f, 6);
    // public static Vector3 river = new Vector3(0,-4,0);
    public static Vector3 left_boat = new Vector3(-1.2f, -0.32f, 6.5f);
    public static Vector3 right_boat = new Vector3(-5.8f, -0.32f, 6.5f);

    // relative position of Role to Shore
    public static Vector3[] role_shore = new Vector3[] {new Vector3(7.5f,0,0), new Vector3(22.5f,0,0), new Vector3(37.5f,0,0), new Vector3(-7.5f,0,0), new Vector3(-22.5f,0,0), new Vector3(-37.5f,0,0)};
    
    // relative position of Role to Boat
    public static Vector3[] role_boat = new Vector3[] {new Vector3(0.6f,0.57f,0), new Vector3(-0.3f,0.57f,0)};


}