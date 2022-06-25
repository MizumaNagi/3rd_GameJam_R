using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFPSCamera : MonoBehaviour
{
    [SerializeField] private float cameraSensitivity;
    [SerializeField, Range(10, 40)] private int rotLimit;

    private Transform myTransform;

    private void Start()
    {
        myTransform = this.transform;
    }

    void Update()
    {
        float mouseVecX = Input.GetAxis("Mouse X");
        float mouseVecY = Input.GetAxis("Mouse Y");

        Vector3 angleXReflection = myTransform.localEulerAngles;
        angleXReflection.x += mouseVecY * -1 * cameraSensitivity;
        if (angleXReflection.x > rotLimit && angleXReflection.x < 180) angleXReflection.x = rotLimit;
        if (angleXReflection.x < 360 - rotLimit && angleXReflection.x > 180) angleXReflection.x = 360 - rotLimit;
        myTransform.localEulerAngles = angleXReflection;

        Vector3 resultAngle = myTransform.localEulerAngles;
        resultAngle.y += mouseVecX * cameraSensitivity;
        myTransform.localEulerAngles = resultAngle;
    }
}
