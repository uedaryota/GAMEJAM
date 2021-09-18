using UnityEngine;
using UnityEditor;

namespace Assets.Scripts
{
    public class Target : Wood
    {
        private float move = 0.01f;
        private bool moveFlag = false;
        public Target(Vector3 pos)
        {
            Model = (GameObject)Resources.Load("Prefabs/Target");
            Create(pos);
        }
        protected override void AppendInitialize()
        {
            moveFlag = false;
        }
        protected override void AppendUpdate()
        {
            Hit();
            Move();
            base.AppendUpdate();
        }

        private void Hit()
        {
            if (Model == null)
                return;
            if(Model.transform.GetComponent<CheckHit>().HitFlag)
            {
                DeadFlag = true;
            }
        }
        private void Move()
        {
            if(Model.transform.position.x>=3.9f)
            {
                moveFlag = true;
                Debug.Log("aa");
            }
            
            if(Model.transform.position.x<=-3.9f)
            {
                moveFlag = false;
                Debug.Log("bb");
            }
            if(moveFlag == true)
            {
                Model.transform.Translate(-move, 0, 0);
            }
            if (moveFlag == false)
            {
                Model.transform.Translate(move, 0, 0);
            }
        }
    }
}