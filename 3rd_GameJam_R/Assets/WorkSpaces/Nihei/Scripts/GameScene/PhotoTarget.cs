using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoTarget : MonoBehaviour
{
    public Transform TargetOriginTrans { get { return targetOriginTrans; } }

    [SerializeField]
    protected int takeScore = 10;
    [SerializeField]
    protected Transform targetOriginTrans = null;
    [SerializeField]
    private PoolableObject poolableObj;

    /// <summary>
    /// 写真を撮られた際の処理
    /// </summary>
    public virtual void OnTakenPhoto()
    {
        GameSceneProperties.Instance.AddGameScore(takeScore);

        poolableObj.DisableObject();
        //Destroy(gameObject);
    }
}
