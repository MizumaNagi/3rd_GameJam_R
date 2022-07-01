using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1)]
public class GameSceneManager : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] disableScriptAfterGame;
    [SerializeField] private GameObject timeText;
    [SerializeField] private GameObject operationText;
    [SerializeField] private Canvas titleCanvas;
    [SerializeField] private ResultCanvas resultCanvas;
    [SerializeField] private UnitGenerator unitGenerator;

    private float gameTime = 10f;
    private bool isGameStart = false;
    private bool isGameFinish = false;

    public bool CanTakePicture { get { return (isGameStart == true && isGameFinish == false); } }

    public static GameSceneManager Instance = null;
    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        GameInit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isGameStart == false)
        {
            GameStart();
        }

        if (isGameStart == false || isGameFinish == true) return;

        gameTime -= Time.deltaTime;
        GameSceneProperties.Instance.UpdateTimeUI(gameTime);

        if(gameTime < 0)
        {
            GameEnd();
        }
    }

    private IEnumerator LateStart()
    {
        yield return null;

        AudioManager.Instance.PlaySE("Bird", null, 0.1f, 1f, Mathf.Infinity, true);
        AudioManager.Instance.PlaySE("Wind", null, 0.1f, 1f, Mathf.Infinity, true);
    }

    private void GameInit()
    {
        isGameStart = false;
        isGameFinish = false;
        timeText.SetActive(false);
        operationText.SetActive(true);
    }

    private void GameStart()
    {
        isGameStart = true;
        titleCanvas.enabled = false;
        timeText.SetActive(true);
        GameSceneProperties.Instance.Init(gameTime);
        unitGenerator.Init();
        foreach (MonoBehaviour m in disableScriptAfterGame)
        {
            m.enabled = true;
        }

        StartCoroutine(LateStart());
    }

    private void GameEnd()
    {
        isGameFinish = true;
        timeText.SetActive(false);
        operationText.SetActive(false);
        resultCanvas.Init();
        foreach (MonoBehaviour m in disableScriptAfterGame)
        {
            m.enabled = false;
        }
    }
}