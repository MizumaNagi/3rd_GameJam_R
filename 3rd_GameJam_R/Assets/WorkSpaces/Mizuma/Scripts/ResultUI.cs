using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private Text copyCntText;
    [SerializeField] private Text copyRankText;
    [SerializeField] private Text copyPointText;
    [SerializeField] private Text distanceCntText;
    [SerializeField] private Text distanceRankText;
    [SerializeField] private Text distancePointText;
    [SerializeField] private Text totalPointText;

    private ResultJudge resultJudge = new ResultJudge();
    private int totalPoint = 0;
    private int copyAddPoint = 0;
    private int distanceAddPoint = 0;
    private int currentIndex = 0;

    public void UpdateInfoUI(int copyCnt, float minDistance)
    {
        int copyRankIndex = resultJudge.GetCopyCntRankIndex(copyCnt);
        copyAddPoint = resultJudge.AddPointEachRank[copyRankIndex];
        string copyRank = resultJudge.RankChar[copyRankIndex];
        copyCntText.text = $"{copyCnt} ‘Ì";
        copyRankText.text = copyRank;
        if (copyAddPoint > 0) copyPointText.text = $"+ {copyAddPoint}";
        else copyPointText.text = $"- {Mathf.Abs(copyAddPoint)}";

        int distanceRankIndex = resultJudge.GetDistanceRankIndex(minDistance);
        distanceAddPoint = resultJudge.AddPointEachRank[distanceRankIndex];
        string distanceRank = resultJudge.RankChar[distanceRankIndex];
        if (minDistance == Mathf.Infinity) distanceCntText.text = "--- m";
        else distanceCntText.text = $"{Mathf.RoundToInt(minDistance)} m";
        distanceRankText.text = distanceRank;
        if (distanceAddPoint > 0) distancePointText.text = $"+ {distanceAddPoint}";
        else distancePointText.text = $"- {Mathf.Abs(distanceAddPoint)}";

        currentIndex++;
    }

    public void UpdateTotalUIFirstColumn()
    {
        totalPoint += copyAddPoint;
        if (totalPoint < 0) totalPoint = 0;

        totalPointText.text = totalPoint.ToString();
    }

    public void UpdateTotalUISecondColumn()
    {
        totalPoint += distanceAddPoint;
        if (totalPoint < 0) totalPoint = 0;

        totalPointText.text = totalPoint.ToString();
    }
}
