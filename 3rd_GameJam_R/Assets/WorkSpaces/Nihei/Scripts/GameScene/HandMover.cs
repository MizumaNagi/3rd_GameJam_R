using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMover : MonoBehaviour
{
    public bool HandUp { get; private set; }

    [SerializeField]
    private Animator animator = null;
    [SerializeField]
    private KeyCode handUpKey = KeyCode.LeftShift;

    private void Update()
    {
        UpdateHandUp();
    }

    private void UpdateHandUp()
    {
        bool inputingHandUpKey = Input.GetKey(handUpKey);
        animator.SetBool("HandUp", inputingHandUpKey);

        HandUp = inputingHandUpKey;
    }
}
