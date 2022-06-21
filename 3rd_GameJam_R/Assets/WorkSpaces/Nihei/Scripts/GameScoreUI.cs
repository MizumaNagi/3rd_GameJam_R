using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScoreUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI valueText = null;

    /// <summary>
    /// スコアをテキストとしてセットする
    /// </summary>
    /// <param name="score"></param>
    public void SetScoreText(int score)
    {
        valueText.SetText("{0}", score);
    }
}
