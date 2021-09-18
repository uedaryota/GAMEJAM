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
    private int maxArrowNum = 12;
    private int arrowNum = 1;

    private int maxTargetNum = 8;
    private List<Target> targets = new List<Target>();

    private List<Vector2> targetPos = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        text.transform.gameObject.SetActive(true);

        bow = new Bow(Vector3.zero);
        bow.Initialize();
        arrowNum = maxArrowNum;

        MakeRandomPos();
        
        for (int i = 0; i < maxTargetNum; i++)
        {
            targets.Add(new Target(new Vector3(targetPos[i].x, 0, targetPos[i].y)));
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
        if (targets.Count <= 0)
            SceneTransition.ResultTransition();
    }

    private void MakeRandomPos()
    {
        while (targetPos.Count < maxTargetNum)
        {
            Vector2 pos = new Vector2(Random.Range(-4, 4), Random.Range(0, 4));
            if (targetPos.Contains(pos))
                continue;

            targetPos.Add(pos);
        }
    }

}
