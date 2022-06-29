using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneProperties : MonoBehaviour
{
    public static GameSceneProperties Instance { get; private set; } = null;
    public int GameScore { get; private set; }
    private float remTime = 60f;

    public GameSceneUICanvas UICanvas { get { return uICanvas; } }

    [SerializeField]
    private GameSceneUICanvas uICanvas = null;

    private void Awake()
    {
        if (Instance != null) return;
        Instance = GetComponent<GameSceneProperties>();
    }

    /// <summary>
    /// ゲームスコアを加算する
    /// </summary>
    /// <param name="value"></param>
    public void AddGameScore(int value)
    {
        GameScore += value;
        UICanvas.GameScoreUI.SetScoreText(GameScore);
    }

    public void UpdateTimeUI(float frameTime)
    {
        remTime -= frameTime;
        remTime = Mathf.Max(remTime, 0f);
        UICanvas.GameTimeUI.SetScoreText((int)remTime);
    }
}
