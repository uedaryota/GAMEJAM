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
    [SerializeField]
    private Slider slider = null;
    [SerializeField]
    private Text ui = null;
    private float uiNum = 1;
    private int vanishFlag = 1;

    private bool canShotFlag = false;

    // 弓
    private Bow bow;
    // 撃てる矢の最大数
    private int maxArrowNum = 5;
    private int arrowNum = 1;

    private int maxTargetNum = 8;
    private List<Target> targets = new List<Target>();

    private List<Vector2> targetPos = new List<Vector2>();

    private int plusMinus = 1;

    // Start is called before the first frame update
    void Start()
    {
        text.transform.gameObject.SetActive(true);

        bow = new Bow(new Vector3(0, 0, -0.5f));
        bow.Initialize();
        arrowNum = maxArrowNum;

        MakeRandomPos();

        for (int i = 0; i < maxTargetNum; i++)
        {
            targets.Add(new Target(new Vector3(targetPos[i].x, 0, targetPos[i].y)));
            targets[i].Initialize();
        }

        ui.transform.gameObject.SetActive(true);
        slider.transform.gameObject.SetActive(true);
        slider.value = 0;

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
        if (Input.GetKeyDown(KeyCode.Space))
            canShotFlag = true;
        CheckUI(canShotFlag);
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
            canShotFlag = false;
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
            Vector2 pos = new Vector2(Random.Range(-4, 4), Random.Range(1, 4));
            if (targetPos.Contains(pos))
                continue;

            targetPos.Add(pos);
        }
    }

    private int GaugeUpdate(in bool flag)
    {
        if (slider.value <= 0)
            plusMinus = 1;
        if (slider.value >= 10)
            plusMinus = -1;
        if (!flag)
        {
            slider.value += plusMinus * Time.deltaTime / arrowNum * 100;
            return 1;
        }
        if (slider.value < 4)
            return 1;
        if (slider.value > 6)
            return 1;
        return 3;
    }

    private void CheckUI(in bool uiFlag)
    {
        bow.CanShotFlag = uiFlag;
        int x = GaugeUpdate(uiFlag);
        if (!uiFlag)
        {
            ui.text = "タイミング良く止めてね！";
            ui.color = new Color(1, 0.75f, 0.3f, uiNum);
            if (uiNum <= 0)
                vanishFlag = 1;
            if (uiNum >= 1)
                vanishFlag = -1;
            uiNum += Time.deltaTime * vanishFlag;
            return;
        }
        ui.text = "SPACEで撃て！";
        ui.color = new Color(1, 0.75f, 0.3f, 1);
        bow.RefNum = x;
    }

}
