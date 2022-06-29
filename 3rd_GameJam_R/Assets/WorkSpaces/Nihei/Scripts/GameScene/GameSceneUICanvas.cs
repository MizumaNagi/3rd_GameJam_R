using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneUICanvas : MonoBehaviour
{
    public GameScoreUI GameScoreUI { get { return gameScoreUI; } }
    public GameScoreUI GameTimeUI { get { return gameTimeUI; } }

    [SerializeField]
    private GameScoreUI gameScoreUI = null;
    [SerializeField]
    private GameScoreUI gameTimeUI = null;
}
