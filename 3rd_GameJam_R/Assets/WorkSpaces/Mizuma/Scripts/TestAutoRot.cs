using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAutoRot : MonoBehaviour
{
    [SerializeField] private float rotSpeed;

    private Transform myTrans;

    private void Start()
    {
        myTrans = this.transform;
    }

    private void FixedUpdate()
    {
        myTrans.rotation *= Quaternion.Euler(new Vector3(rotSpeed, 0, 0));
    }
}
