using UnityEngine;
using UnityEditor;

namespace Assets.Scripts
{
    public class Arrow : Wood
    {
        private float moveSpeed = 8;
        private int reflectNum = 1;
        private bool canDeadFlag = false;
        private int score = 0;
        private int addScore = 350;

        public int ReflectNum { get => reflectNum; set => reflectNum = value; }
        public int Score { get => score; }

        public Arrow(Vector3 pos)
        {
            Model = (GameObject)Resources.Load("Prefabs/Arrow");
            Create(pos);
        }

        protected override void AppendUpdate()
        {
            Move();
            CheckScreen();
            DirChange();
            base.AppendUpdate();
        }

        private void Move()
        {
            Model.transform.position += Model.transform.forward * moveSpeed * Time.deltaTime;
        }

        private void DirChange()
        {
            if (Model == null)
                return;
            if (Model.transform.GetComponent<CheckHit>().HitFlag)
            {
                score += addScore;
                addScore *= 3;
                Model.transform.GetComponent<CheckHit>().HitFlag = false;
            }
        }

        private void CheckScreen()
        {
            canDeadFlag = reflectNum <= 0 ? true : false;
            if (Model.transform.position.x >= 6)
            {
                Model.transform.eulerAngles = -Model.transform.eulerAngles;
                reflectNum--;
                DeadFlag = canDeadFlag ? true : false;
                return;
            }
            if (Model.transform.position.x <= -6)
            {
                Model.transform.eulerAngles = -Model.transform.eulerAngles;
                reflectNum--;
                DeadFlag = canDeadFlag ? true : false;
                return;
            }
            if (Model.transform.position.z <= -1)
            {
                Model.transform.eulerAngles = new Vector3(0, 180, 0) - Model.transform.eulerAngles;
                reflectNum--;
                DeadFlag = canDeadFlag ? true : false;
                return;
            }
            if (Model.transform.position.z >= 5)
            {
                Model.transform.eulerAngles = new Vector3(0,180,0)-Model.transform.eulerAngles;
                reflectNum--;
                DeadFlag = canDeadFlag ? true : false;
                return;
            }
        }

    }
}