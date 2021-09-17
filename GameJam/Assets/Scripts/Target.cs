using UnityEngine;
using UnityEditor;

namespace Assets.Scripts
{
    public class Target : Wood
    {
        public Target(Vector3 pos)
        {
            Model = (GameObject)Resources.Load("Prefabs/Target");
            Create(pos);
        }
      
        protected override void AppendUpdate()
        {
            Hit();
            base.AppendUpdate();
        }

        private void Hit()
        {
            if(Model.GetComponent<Checkhit>().HitFlag == true)
            {

                DeadFlag = true;
            }
        }
    }
}