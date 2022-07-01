using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGenerator : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private UnitSpawnInfos unitSpawnInfos;
    [SerializeField] private SpawnDataSetting spawnDataSetting;
    [SerializeField] private Transform enemyPoolTrans;

    private Vector3 enemyPoolWorldPos;

    private void Start()
    {
        enemyPoolWorldPos = enemyPoolTrans.position;
        unitSpawnInfos.Init();

        while(true)
        {
            UnitSpawnInfo targetSpawnGroup = unitSpawnInfos.GetNextSpawnInfo();
            if (targetSpawnGroup == null) break;
            StartCoroutine(WaitPop(targetSpawnGroup));
        }
    }

    private IEnumerator WaitPop(UnitSpawnInfo targetSpawnInfo)
    {
        Debug.Log("WaitPop");
        float waitTime = targetSpawnInfo.startTime;
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(Pop(targetSpawnInfo, 0));
    }

    private IEnumerator Pop(UnitSpawnInfo targetSpawnInfo, int currentUnitIndex)
    {
        float delayTime = targetSpawnInfo.spawnDelaySecond;
        int unitArrLength = targetSpawnInfo.spawnCount;

        yield return new WaitForSeconds(delayTime);
        GameObject popUnit = objectPool.GetObject<PoolableObject>().gameObject;

        popUnit.transform.localPosition = spawnDataSetting.baseSpawnPos
            + spawnDataSetting.spawnPosEachFormations[(int)targetSpawnInfo.unitFormation].posArr[currentUnitIndex];
        popUnit.transform.rotation = Quaternion.identity;

        popUnit.transform.RotateAround(enemyPoolWorldPos, Vector3.up, targetSpawnInfo.spawnRotation);
        popUnit.GetComponent<UnitAnimation>().Init(
            targetSpawnInfo.unitMoveStyle,
            targetSpawnInfo.unitArriveMoveStyle,
            spawnDataSetting.speedMultiArr[(int)targetSpawnInfo.unitMoveSpeed]);

        currentUnitIndex++;
        if (currentUnitIndex < unitArrLength) StartCoroutine(Pop(targetSpawnInfo, currentUnitIndex));
    }
}
