using UnityEngine;

[CreateAssetMenu(fileName = "UnitSpawnInfos", menuName = "ScriptableObject/UnitSpawnInfos")]
public class UnitSpawnInfos : ScriptableObject
{
    [SerializeField] private UnitSpawnInfo[] unitSpawnInfos;
    [SerializeField] private bool randomMode;
    [SerializeField] private RandomSpawnDataEachDiff rndSpawnInfos;
    [SerializeField] private float totalGameTime;

    private float[] selectRangeEachDiff = { 0.2f, 0.4f, 0.2f, 0.1f, 0.1f };
    private float deltaTime = 0f;

    private int currentIndex = 0;

    public void Init()
    {
        currentIndex = 0;
        deltaTime = 0f;
    }

    public UnitSpawnInfo GetNextSpawnInfo()
    {
        if(randomMode == true)
        {
            if (deltaTime > totalGameTime) return null;
            UnitSpawnInfo result = new UnitSpawnInfo();

            // スポーン規模決定
            float rnd = Random.Range(0f, 1f);
            int diffIndex = 0; float totalDiffVal = 0f;
            while(true)
            {
                if (rnd < totalDiffVal) break;
                totalDiffVal += selectRangeEachDiff[diffIndex];
                diffIndex++;
            }
            RandomSpawnData rndSpawnData = rndSpawnInfos.randomSpawnDatas[diffIndex - 1];

            // 規模に応じたデータ取得
            float startTime = deltaTime + Random.Range(rndSpawnData.minRndAddStartTime, rndSpawnData.maxRndAddStartTime);
            int spawnCount = Random.Range(rndSpawnData.minRndSpawnCnt, rndSpawnData.maxRndSpawnCnt + 1);
            int spawnRotation = Random.Range(0, 360);
            float spawnDelaySecond = Random.Range(rndSpawnData.minRndSpawnDelaySec, rndSpawnData.maxRndSpawnDelaySec);
            int rndUnitMoveSpeedIndex = Random.Range(0, rndSpawnData.rndUnitMoveSpeedArr.Length);
            UNIT_MOVE_SPEED unitMoveSpeed = rndSpawnData.rndUnitMoveSpeedArr[rndUnitMoveSpeedIndex];
            int rndUnitFormationIndex = Random.Range(0, rndSpawnData.rndUnitFormationArr.Length);
            UNIT_FORMATION unitFormation = rndSpawnData.rndUnitFormationArr[rndUnitFormationIndex];
            int rndUnitMoveStyleIndex = Random.Range(0, rndSpawnData.rndUnitMoveStyleArr.Length);
            UNIT_MOVE_STYLE unitMoveStyle = rndSpawnData.rndUnitMoveStyleArr[rndUnitMoveStyleIndex];
            int rndUnitArriveMoveStyleIndex = Random.Range(0, rndSpawnData.rndUnitArriveMoveStyleArr.Length);
            UNIT_ARRIVE_MOVE_STYLE unitArriveMoveStyle = rndSpawnData.rndUnitArriveMoveStyleArr[rndUnitArriveMoveStyleIndex];

            // ランダムデータ反映
            result.startTime = startTime;
            result.unitType = UNIT_TYPE.NORMAL;
            result.spawnCount = spawnCount;
            result.spawnRotation = spawnRotation;
            result.spawnDelaySecond = spawnDelaySecond;
            result.unitMoveSpeed = unitMoveSpeed;
            result.unitFormation = unitFormation;
            result.unitMoveStyle = unitMoveStyle;
            result.unitArriveMoveStyle = unitArriveMoveStyle;

            deltaTime = startTime;

            return result;
        }
        else
        {
            if (currentIndex >= unitSpawnInfos.Length) return null;

            UnitSpawnInfo result = unitSpawnInfos[currentIndex];
            currentIndex++;
            return result;
        }
    }
}
