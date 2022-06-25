using UnityEngine;

[CreateAssetMenu(fileName = "SpawnDataSetting", menuName = "ScriptableObject/SpawnDataSetting")]
public class SpawnDataSetting : ScriptableObject
{
    public Vector3 baseSpawnPos;
    public SpawnPosEachFormation[] spawnPosEachFormations;
    public float[] speedMultiArr;
}