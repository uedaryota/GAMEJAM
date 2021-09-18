using UnityEngine;
using UnityEditor;

namespace Assets.Scripts
{
    public class Arrow : Wood
    {
        private float moveSpeed = 4;
        private int reflectNum = 1;
        private bool canDeadFlag = false;

        public int ReflectNum { get => reflectNum; set => reflectNum = value; }

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
                Model.transform.GetComponent<CheckHit>().HitFlag = false;
            }
        }

        private void CheckScreen()
        {
            canDeadFlag = reflectNum <= 0 ? true : false;
            if (Model.transform.position.z >= 5)
            {
                Model.transform.eulerAngles += new Vector3(0, 180, 0);
                reflectNum--;
                DeadFlag = canDeadFlag ? true : false;
                return;
            }
            if (Model.transform.position.x <= -5)
            {
                Model.transform.eulerAngles += new Vector3(0, 180, 0);
                reflectNum--;
                DeadFlag = canDeadFlag ? true : false;
                return;
            }
            if (Model.transform.position.x >= 5)
            {
                Model.transform.eulerAngles += new Vector3(0,180, 0);
                reflectNum--;
                DeadFlag = canDeadFlag ? true : false;
                return;
            }
            if (Model.transform.position.z <= -2)
            {
                Model.transform.eulerAngles += new Vector3(0, 180, 0);
                reflectNum--;
                DeadFlag = canDeadFlag ? true : false;
                return;
            }

        }

    }
}