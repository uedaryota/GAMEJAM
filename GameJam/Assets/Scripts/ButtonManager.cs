using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    GameObject scenetransition;
    SceneTransition scene;
    private void Start()
    {
        scenetransition = GameObject.Find("SceneTransition");
        scene = scenetransition.GetComponent<SceneTransition>();
    }
    public void OnClickStartButton()
    {
        if(name == "StartButton")
        {
            scene.GameSceneTransition();
        }
        if(name == "TitleButton")
        {
            scene.TitleSceneTransition();
        }
        if(name == "GameEndButton")
        {
            scene.Quit();
        }
    }
}
