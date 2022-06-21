using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScoreUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI valueText = null;

    /// <summary>
    /// �X�R�A���e�L�X�g�Ƃ��ăZ�b�g����
    /// </summary>
    /// <param name="score"></param>
    public void SetScoreText(int score)
    {
        valueText.SetText("{0}", score);
    }
}
