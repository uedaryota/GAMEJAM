using UnityEngine;
using UnityEditor;

namespace Assets.Scripts
{
    public class Arrow : Wood
    {
        private float moveSpeed = 4;

        public Arrow(Vector3 pos)
        {
            Model = (GameObject)Resources.Load("Prefabs/Arrow");
            Create(pos);
        }

        protected override void AppendUpdate()
        {
            Move();
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
            if(Model.transform.GetComponent<CheckHit>().HitFlag)
            {
                Model.transform.eulerAngles += new Vector3(0, Random.Range(-180, 180), 0);
                Model.transform.GetComponent<CheckHit>().HitFlag = false;
            }
        }

    }
}