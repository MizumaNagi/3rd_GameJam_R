using UnityEngine;

[CreateAssetMenu(fileName = "UnitSpawnInfos", menuName = "ScriptableObject/UnitSpawnInfos")]
public class UnitSpawnInfos : ScriptableObject
{
    [SerializeField] private UnitSpawnInfo[] unitSpawnInfos;

    private int currentIndex = 0;

    public void Init()
    {
        currentIndex = 0;
    }

    public UnitSpawnInfo GetNextSpawnInfo()
    {
        if (currentIndex >= unitSpawnInfos.Length) return null;

        UnitSpawnInfo result = unitSpawnInfos[currentIndex];
        currentIndex++;
        return result;
    }
}
