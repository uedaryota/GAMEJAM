using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    [SerializeField] // 背景
    private GameObject Stage = null;

    // 弓
    private Bow bow;
    // 撃てる矢の最大数
    private int maxArrowNum = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        bow = new Bow(Vector3.up);
        bow.Initialize();

    }

    // Update is called once per frame
    void Update()
    {
        bow.Update();
        bowCheck();
        
    }

    private void bowCheck()
    {
        //if (arrowNum <= 0)
        //{
        //    SceneTransition.ResultTransition();
        //}
        //if (bow.ShotFlag)
        //{
        //    arrowNum--;
        //    bow.ShotFlag = false;
        //}
    }
}
