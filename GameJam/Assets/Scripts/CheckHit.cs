using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHit : MonoBehaviour
{
    private bool hitFlag = false;

    public bool HitFlag { get => hitFlag; set => hitFlag = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(transform.tag == "Target")
        {
            if(col.transform.tag == "Arrow")
            {
                hitFlag = true;
                return;
            }
        }
        if (transform.tag == "Arrow")
        {
            if (col.tag == "Target")
            {
                hitFlag = true;
                return;
            }
        }
        
    }
}
