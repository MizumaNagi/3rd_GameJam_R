using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameSceneManager : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] disableScriptAfterGame;
    [SerializeField] private ResultCanvas resultCanvas;

    private float gameTime = 5f;
    private bool isGameFinish = false;

    private void Start()
    {
        GameStart();
    }

    private void Update()
    {
        if (isGameFinish == true) return;

        gameTime -= Time.deltaTime;
        GameSceneProperties.Instance.UpdateTimeUI(gameTime);

        if(gameTime < 0)
        {
            GameEnd();
        }
    }

    private void GameStart()
    {
        isGameFinish = false;
        GameSceneProperties.Instance.Init(gameTime);
        foreach (MonoBehaviour m in disableScriptAfterGame)
        {
            m.enabled = true;
        }
    }

    private void GameEnd()
    {
        isGameFinish = true;
        resultCanvas.Init();
        foreach (MonoBehaviour m in disableScriptAfterGame)
        {
            m.enabled = false;
        }
    }
}
