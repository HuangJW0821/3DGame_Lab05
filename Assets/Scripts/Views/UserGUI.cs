using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    IUserAction userAction;
    public string gameMessage ;
    public int time;
    GUIStyle style, bigstyle;
    // Start is called before the first frame update
    void Start()
    {
        time = 60;
        userAction = SSDirector.GetInstance().CurrentSceneController as IUserAction;

        style = new GUIStyle();
        style.normal.textColor = Color.black;
        style.fontSize = 30;

        bigstyle = new GUIStyle();
        bigstyle.normal.textColor = Color.blue;
        bigstyle.fontSize = 50;
    }

    // Update is called once per frame
    void OnGUI() {
        // userAction.Check();
        GUI.Label(new Rect((Screen.width - 250) / 2, 0, 200, 200), "Preists & Demons", bigstyle);
        GUI.Label(new Rect((Screen.width - 50) / 2, 100, 50, 200), gameMessage, style);
        GUI.Label(new Rect(0,0,100,50), "Time: " + time, style);

        if (GUI.Button(new Rect((Screen.width - 100) / 2, Screen.height - 100, 100, 50), "Reset"))
            userAction.ResetGame();
    }
}