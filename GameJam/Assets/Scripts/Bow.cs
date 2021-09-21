using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class Bow : Wood
    {
        private float rotateSpeed = 30;

        // 矢の管理をする
        private Arrow arrow;

        private float arrowPos = 0;

        private int refNum = 1;

        private bool canShotFlag = false;

        private bool shotFlag = false;

        // 弓が持っているスコアの合計
        public int score = 0;
        public bool CanShotFlag { get => canShotFlag; set => canShotFlag = value; }
        public bool ShotFlag { get => shotFlag; set => shotFlag = value; }
        public int RefNum { get => refNum; set => refNum = value; }

        public Bow(Vector3 pos)
        {
            Model = (GameObject)Resources.Load("Prefabs/Bow");
            Create(pos);
        }


        protected override void AppendUpdate()
        {
            Model.transform.GetChild(1).transform.gameObject.SetActive(arrow == null);
            if (arrow != null)
            {
                arrow.Update();
                if (arrow.DeadFlag)
                {
                    score += arrow.Score;
                    arrow = null;
                    shotFlag = true;
                }
            }
            else
            {
                if (arrowPos >= 3)
                    arrowPos = 0;
                arrowPos += Time.deltaTime * 3;
                Model.transform.GetChild(1).position = Model.transform.forward * arrowPos;
            }
            CheckInput();
        }

        private void CheckInput()
        {
            if (Input.GetKey(KeyCode.A))
            {
                Move("A");
            }
            if (Input.GetKey(KeyCode.D))
            {
                Move("D");
            }
            if (Input.GetKeyDown(KeyCode.Space) && canShotFlag)
            {
                Shot();
            }
        }

        private void Move(in string dir)
        {
            if (dir == "A")
            {
                Model.transform.eulerAngles -= Vector3.up * rotateSpeed * Time.deltaTime;
                return;
            }
            if (dir == "D")
                Model.transform.eulerAngles += Vector3.up * rotateSpeed * Time.deltaTime;

        }

        private void Shot()
        {
            if (arrow != null)
                return;
            arrow = new Arrow(Model.transform.position);
            arrow.Initialize();
            arrow.ReflectNum = refNum;
            arrow.Model.transform.rotation = Model.transform.rotation;
        }

        
    }
}