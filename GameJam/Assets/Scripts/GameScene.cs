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

    // 矢の管理をする
    private List<Arrow> arrows = new List<Arrow>();

    // Start is called before the first frame update
    void Start()
    {
        bow = new Bow();
        bow.Create(Vector3.up);
        bow.Initialize();

        arrows.Add(new Arrow());
        foreach (var a in arrows)
        {
            a.Create(Vector3.up);
            a.Initialize();
        }
    }

    // Update is called once per frame
    void Update()
    {
        bow.Update();

        foreach (var a in arrows)
        {
            a.Update();
        }
    }
}
