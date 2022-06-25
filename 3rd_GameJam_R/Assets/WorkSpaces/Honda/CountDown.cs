using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text timertext;
    public bool isTimeUp;
    public bool timeStop = false;

    public int Minute;
    public float Seconds;
    private float oldSecomds;
    private float tortaltime;

    void Start()
    {
        isTimeUp = false;
    }

    void Update()
    {
        if (!isTimeUp && Seconds < 0)
        {
            TimeUp();
        }

        if (timeStop)
        {
            UpdateTimeText();

            return;
        }

        CountDownTimer();

        //(分)で表示
        if ((int)Seconds != (int)oldSecomds)
        {
            UpdateTimeText();
            oldSecomds = Seconds;
        }

    }

    // カウントダウン
    public void CountDownTimer()
    {
        tortaltime = Minute * 60 + Seconds;
        tortaltime -= Time.deltaTime;

        Minute = (int)tortaltime / 60;
        Seconds = tortaltime - Minute * 60;
    }
    public void CountStart()
    {
        timeStop = false;
    }

    // カウントダウンを停止
    public void CountStop()
    {
        timeStop = true;
    }

    private void TimeUp()
    {
        isTimeUp = true;
        // timertext.text = "TimeUp!!";

        CountStop();
    }

    private void UpdateTimeText()
    {
        timertext.text = Minute.ToString("0") + ":" + ((int)Seconds).ToString("00");
    }
}
