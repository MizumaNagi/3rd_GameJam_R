[System.Serializable]
public class RandomSpawnData
{
    public float minRndAddStartTime;
    public float maxRndAddStartTime;

    public int minRndSpawnCnt;
    public int maxRndSpawnCnt;

    public float minRndSpawnDelaySec;
    public float maxRndSpawnDelaySec;

    public UNIT_MOVE_SPEED[] rndUnitMoveSpeedArr;
    public UNIT_FORMATION[] rndUnitFormationArr;
    public UNIT_MOVE_STYLE[] rndUnitMoveStyleArr;
    public UNIT_ARRIVE_MOVE_STYLE[] rndUnitArriveMoveStyleArr;
}
