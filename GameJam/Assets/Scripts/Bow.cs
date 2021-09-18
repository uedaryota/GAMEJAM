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

        private bool shotFlag = false;
        public bool ShotFlag { get => shotFlag; set => shotFlag = value; }



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
                CheckScreen();
                if (arrow.DeadFlag)
                {
                    arrow = null;
                    shotFlag = true;
                }
            }
            else
            {
                if (arrowPos >= 3)
                    arrowPos = 0;
                arrowPos += Time.deltaTime*3;
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
            if (Input.GetKeyDown(KeyCode.Space))
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
            arrow.Model.transform.rotation = Model.transform.rotation;
        }

        private void CheckScreen()
        {
            if (arrow.Model.transform.position.z >= 5)
            {
                arrow.DeadFlag = true;
                return;
            }
            if (arrow.Model.transform.position.x <= -5)
            {
                arrow.DeadFlag = true;
                return;
            }
            if (arrow.Model.transform.position.x >= 5)
            {
                arrow.DeadFlag = true;
                return;
            }
            if (arrow.Model.transform.position.z <= -2)
            {
                arrow.DeadFlag = true;
                return;
            }

        }
    }
}