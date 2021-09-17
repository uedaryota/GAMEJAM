using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private Text text;
    private int rank1, rank2, rank3;

    void Start()
    {
        text = GameObject.Find("ScoreText").GetComponent<Text>();

        text.text = "1:" + rank1 + "\n" + "2:" + rank2 + "\n" + "3:" + rank3;
    }

    public void SetRank(int num1, int num2, int num3)
    {
        rank1 = num1;
        rank2 = num2;
        rank3 = num3;
    }
}
