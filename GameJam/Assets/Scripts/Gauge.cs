﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    public Slider gauge;//ゲージ
    bool plus;//plusに動く時はtrueになる
    float bowLife;//矢のライフ
    bool buttonPush;//ボタンを押しているとtrue
    float bowPower;//矢の力
    // Start is called before the first frame update
    void Start()
    {
        bowPower = 0;
        gauge.value = 0;
        bowLife = 0.05f;
        plus = true;
        buttonPush = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            buttonPush = true;
            if (gauge.value <= 5 && plus)
            {
                gauge.value += bowLife;
            }
            if (gauge.value == 5 && plus)
            {
                plus = false;
            }
            if (gauge.value >= 0 && !plus)
            {
                gauge.value -= bowLife;
            }
            if (gauge.value == 0 && !plus)
            {
                plus = true;
            }
            gauge.value = bowPower;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            buttonPush = false;
            gauge.value = 0;
        }
    }

    public float getBowLife(float i)
    {
        return bowLife + (i/100);
    }
    public float getBowPower()
    {
        return bowPower;
    }
}
