using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cockatiel : MonoBehaviour
{
    private Animator cockatiel;
    public GameObject Script;

	void Start ()
    {
        cockatiel = GetComponent<Animator>();
	}
	
	void Update ()
    {
        if (cockatiel.GetCurrentAnimatorStateInfo(0).IsName("takeoff"))
        {
            cockatiel.SetBool("landing", false);
        }
        if (cockatiel.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            cockatiel.SetBool("takeoff", false);
            cockatiel.SetBool("landing", false);
            cockatiel.SetBool("fly", false);
        }
        if (cockatiel.GetCurrentAnimatorStateInfo(0).IsName("fly"))
        {
            cockatiel.SetBool("idle", false);
            cockatiel.SetBool("walk", false);
            cockatiel.SetBool("turnleft", false);
            cockatiel.SetBool("turnright", false);
        }
        if (cockatiel.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            cockatiel.SetBool("flyleft", false);
            cockatiel.SetBool("flyright", false);
            cockatiel.SetBool("fly", false);
            cockatiel.SetBool("idle", false);
        }
        if ((Input.GetKeyUp(KeyCode.W))||(Input.GetKeyUp(KeyCode.A))||(Input.GetKeyUp(KeyCode.D))||(Input.GetKeyUp(KeyCode.E)))
        {
            cockatiel.SetBool("walk", false);
            cockatiel.SetBool("idle", true);
            cockatiel.SetBool("fly", true);
            cockatiel.SetBool("turnleft", false);
            cockatiel.SetBool("turnright", false);
            cockatiel.SetBool("flyleft", false);
            cockatiel.SetBool("flyright", false);
            cockatiel.SetBool("eat", false);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            cockatiel.SetBool("walk", true);
            cockatiel.SetBool("idle", false);
            cockatiel.SetBool("turnleft", false);
            cockatiel.SetBool("turnright", false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            cockatiel.SetBool("turnleft", true);
            cockatiel.SetBool("turnright", false);
            cockatiel.SetBool("flyleft", true);
            cockatiel.SetBool("flyright", false);
            cockatiel.SetBool("walk", false);
            cockatiel.SetBool("idle", false);
            cockatiel.SetBool("fly", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            cockatiel.SetBool("turnright", true);
            cockatiel.SetBool("turnleft", false);
            cockatiel.SetBool("flyright", true);
            cockatiel.SetBool("flyleft", false);
            cockatiel.SetBool("walk", false);
            cockatiel.SetBool("idle", false);
            cockatiel.SetBool("fly", false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            cockatiel.SetBool("eat", true);
            cockatiel.SetBool("idle", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cockatiel.SetBool("takeoff", true);
            cockatiel.SetBool("idle", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cockatiel.SetBool("fly", false);
            cockatiel.SetBool("landing", true);
            cockatiel.SetBool("flyleft", false);
            cockatiel.SetBool("flyright", false);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            cockatiel.SetBool("fly", false);
            cockatiel.SetBool("glide", true);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            cockatiel.SetBool("glide", false);
            cockatiel.SetBool("fly", true);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            cockatiel.SetBool("dancing", true);
            cockatiel.SetBool("idle", false);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            cockatiel.SetBool("dancing", false);
            cockatiel.SetBool("idle", true);
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            Script.GetComponent<CameraFollow>().enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.RightControl))
        {
            Script.GetComponent<CameraFollow>().enabled = true;
        }
    }
}
