using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AutoRotNoPlay : MonoBehaviour
{
    [SerializeField] private Vector3 autoRotVec;

    private Transform myTrans;

    private void Start()
    {
        myTrans = this.transform;
    }

    private void Update()
    {
        Debug.Log("As");
        myTrans.rotation *= Quaternion.Euler(autoRotVec);
    }
}
