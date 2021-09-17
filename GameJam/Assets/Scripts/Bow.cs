using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class Bow : Wood
    {
        private float rotateSpeed = 20;

        // 矢の管理をする
        private List<Arrow> arrows = new List<Arrow>();

        private bool shotFlag = false;
        public bool ShotFlag { get => shotFlag; set => shotFlag = value; }

        public Bow(Vector3 pos)
        {
            Model = (GameObject)Resources.Load("Prefabs/Bow");
            Create(pos);
        }


        protected override void AppendUpdate()
        {
            foreach (var a in arrows)
            {
                a.Update();
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
            arrows.Add(new Arrow(Model.transform.position));
            arrows[arrows.Count - 1].Initialize();
            arrows[arrows.Count - 1].Model.transform.rotation = Model.transform.rotation;
            shotFlag = true;
        }
    }
}