using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGenerator : MonoBehaviour
{
    [SerializeField] private GameObject unitPrefab;
    [SerializeField] private UnitSpawnInfos unitSpawnInfos;
    [SerializeField] private SpawnDataSetting spawnDataSetting;

    private UnitSpawnInfo targetSpawnInfo;

    private void Start()
    {
        unitSpawnInfos.Init();

        targetSpawnInfo = unitSpawnInfos.GetNextSpawnInfo();
        StartCoroutine(Generate(targetSpawnInfo.spawnDelaySecond, 0, targetSpawnInfo.spawnCount));
    }

    private IEnumerator Generate(float delayTime, int unitArrIndex, int unitArrLength)
    {
        yield return new WaitForSeconds(delayTime);
        GameObject newObj = Instantiate(unitPrefab,
            spawnDataSetting.baseSpawnPos + spawnDataSetting.spawnPosEachFormations[(int)targetSpawnInfo.unitFormation].posArr[unitArrIndex],
            Quaternion.identity);

        newObj.transform.RotateAround(Vector3.zero, Vector3.up, targetSpawnInfo.spawnRotation);
        newObj.GetComponent<UnitAnimation>().Init(
            targetSpawnInfo.unitMoveStyle,
            targetSpawnInfo.unitArriveMoveStyle,
            spawnDataSetting.speedMultiArr[(int)targetSpawnInfo.unitMoveSpeed]);

        unitArrIndex++;
        if (unitArrIndex < unitArrLength) StartCoroutine(Generate(delayTime, unitArrIndex, unitArrLength));
    }
}
