using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFinishFireWork : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;

    private ParticleSystem.MainModule mainModule;

    private void Start()
    {
        mainModule = particle.main;
        mainModule.stopAction = ParticleSystemStopAction.Callback;
    }

    private void OnParticleSystemStopped()
    {
        Debug.Log("true");
        AudioManager.Instance.PlaySE("FireWork");
    }
}
