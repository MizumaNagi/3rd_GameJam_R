using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BardDesolve : MonoBehaviour
{
    public SkinnedMeshRenderer[] MainMaterial;
    
    public float alpha;
    public float alpha2;

    private void Start()
    {
        MainMaterial = GetComponentsInChildren<SkinnedMeshRenderer>();
        
    }
    // Update is called once per frame
    void Update()
    {
        MainMaterial[0].material.SetFloat("_DesolveSpeed", alpha);
        MainMaterial[1].material.SetFloat("_DesolveSpeed", alpha);
        MainMaterial[2].material.SetFloat("_Cutoff", alpha2);

        alpha += Time.deltaTime;
        alpha2-= Time.deltaTime;
    }
}
