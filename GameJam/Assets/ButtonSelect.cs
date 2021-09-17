using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{
    private Button FirstSelectButton;

    void Start()
    {
        if (name == "TitlePanel")
        {
            FirstSelectButton = GameObject.Find("StartButton").GetComponent<Button>();
        }
        if(name == "ResultPanel")
        {
            FirstSelectButton = GameObject.Find("TitleButton").GetComponent<Button>();
        }
        FirstSelectButton.Select();
    }
}
