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
            base.AppendUpdate();
        }

        private void Move()
        {
            Model.transform.position += Model.transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}