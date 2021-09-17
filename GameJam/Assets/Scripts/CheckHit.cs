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

    void OnCollisionEnter(Collider col)
    {
        hitFlag = true;
    }
}
