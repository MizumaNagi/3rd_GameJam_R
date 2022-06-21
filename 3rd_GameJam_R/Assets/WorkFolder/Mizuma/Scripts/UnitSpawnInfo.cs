using UnityEngine;

[System.Serializable]
public class UnitSpawnInfo
{
    public UNIT_TYPE unitType;
    [Range(1, 10)] public int spawnCount;
    [Range(0, 360)] public int spawnRotation;
    [Min(0)] public float spawnDelaySecond;
    public UNIT_MOVE_SPEED unitMoveSpeed;
    public UNIT_FORMATION unitFormation;
    public UNIT_MOVE_STYLE unitMoveStyle;
    public UNIT_ARRIVE_MOVE_STYLE unitArriveMoveStyle;
}
