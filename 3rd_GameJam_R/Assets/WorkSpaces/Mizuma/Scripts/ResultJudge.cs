using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultJudge
{
    // ƒ‰ƒ“ƒN: S, A, B, C, F
    private string[] rankChar = { "S", "A", "B", "C", "F" };
    private int[] copyCntBorder = { 6, 4, 2, 1, 0 };
    private float[] distanceBorder = { 5f, 15f, 25f, 40f, Mathf.Infinity };
    private int[] addPointEachRank = { 9, 6, 3, 1, -1 };

    public string[] RankChar => rankChar;
    public int[] AddPointEachRank => addPointEachRank;

    public int GetCopyCntRankIndex(int copyCnt)
    {
        for(int i = 0; i < rankChar.Length; i++)
        {
            if (copyCnt >= copyCntBorder[i]) return i;
        }

        return 4;
    }

    public int GetDistanceRankIndex(float minDistance)
    {
        for (int i = 0; i < rankChar.Length; i++)
        {
            if (minDistance <= distanceBorder[i]) return i;
        }

        return 4;
    }
}
