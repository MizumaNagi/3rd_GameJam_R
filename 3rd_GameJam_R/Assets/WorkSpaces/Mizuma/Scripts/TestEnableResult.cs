using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnableResult : MonoBehaviour
{
    [SerializeField] private ResultCanvas resultCanvas;

    private bool isResultEnabled = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isResultEnabled == true) return;

            resultCanvas.Init();
            isResultEnabled = true;
        }
    }
}
