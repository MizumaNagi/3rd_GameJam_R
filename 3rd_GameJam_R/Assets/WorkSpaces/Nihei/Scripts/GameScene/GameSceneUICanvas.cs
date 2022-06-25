using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneUICanvas : MonoBehaviour
{
    public GameScoreUI GameScoreUI { get { return gameScoreUI; } }

    [SerializeField]
    private GameScoreUI gameScoreUI = null;
}
