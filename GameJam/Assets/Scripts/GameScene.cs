using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    [SerializeField] // 背景
    private GameObject Stage = null;
    [SerializeField]
    private Text text = null;

    // 弓
    private Bow bow;
    // 撃てる矢の最大数
    private int maxArrowNum = 5;
    private int arrowNum = 1;

    private int maxTargetNum = 5;
    private List<Target> targets = new List<Target>();

    // Start is called before the first frame update
    void Start()
    {
        text.transform.gameObject.SetActive(true);

        bow = new Bow(Vector3.up);
        bow.Initialize();
        arrowNum = maxArrowNum;

        for (int i = 0; i < maxTargetNum; i++)
        {
            targets.Add(new Target(new Vector3(Random.Range(-4, 4), 1, Random.Range(4, 0))));
            targets[i].Initialize();
        }
    }

    // Update is called once per frame
    void Update()
    {
        text.text = arrowNum.ToString();
        bow.Update();
        bowCheck();

        foreach (var t in targets)
            t.Update();

        TargetCheck();
    }

    private void bowCheck()
    {
        if (arrowNum <= 0)
        {
            SceneTransition.ResultTransition();
        }
        if (bow.ShotFlag)
        {
            arrowNum--;
            bow.ShotFlag = false;
        }
    }

    private void TargetCheck()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i].DeadFlag)
                targets.RemoveAt(i);
        }
        if(targets.Count <= 0)
            SceneTransition.ResultTransition();
    }
}
