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
    /// �ʐ^���B��ꂽ�ۂ̏���
    /// </summary>
    public virtual void OnTakenPhoto()
    {
        GameSceneProperties.Instance.AddGameScore(takeScore);

        poolableObj.DisableObject();
        //Destroy(gameObject);
    }
}
