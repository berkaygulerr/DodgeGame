using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    float sec = 0;
    public Text timeText;
    public Text scoreText;
    public Text recordText;
    
    void Update()
    {
        //PlayerPrefs.SetFloat("timeSave", 0);
        if (GameManager.gameOver)
        {
            timeText.enabled = false;
            scoreText.enabled = true;
            recordText.enabled = true;
        }
        else if (!GameManager.gameOver && !GameManager.baslangic)
        {
            timeText.enabled = true;
            scoreText.enabled = false;
            recordText.enabled = false;
            CalculateSec();
        }
    }

    void CalculateSec()
    {
        sec += Time.deltaTime;
        timeText.text = sec.ToString("0.0") + " sn";
    }

    public void TimeSave()
    {
        if (sec > PlayerPrefs.GetFloat("timeSave"))
        {
            PlayerPrefs.SetFloat("timeSave", sec);

            ShowRecordScore("NEW RECORD TIME");
        }
        else
        {
            ShowRecordScore("RECORD TIME");
        }

        ShowScore();
    }

    void ShowScore()
    {
        scoreText.text = "SCORE TİME: " + timeText.text;
    }

    void ShowRecordScore(string text)
    {
        recordText.text = text + ": " + PlayerPrefs.GetFloat("timeSave").ToString("0.0") + " sn";
    }
}
