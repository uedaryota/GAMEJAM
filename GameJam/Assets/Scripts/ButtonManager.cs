using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void OnClickStartButton()
    {
        if(name == "StartButton")
        {
            SceneTransition.GameSceneTransition();
        }
        if(name == "TitleButton")
        {
            SceneTransition.TitleSceneTransition();
        }
        if(name == "GameEndButton")
        {
            SceneTransition.Quit();
        }
    }
}
