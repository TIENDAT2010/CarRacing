using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGUIManager : Singleton<GameGUIManager>
{
    public GameObject homeGui;
    public GameObject gameGui;
    public Text timeCoutingText;
    public Text scoreCountingText;
    public Dialog gameOverDialog;
    public Dialog pauseDialog;

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public void ShowGameGUI(bool isShow)
    {
        if(gameGui)
        {
            gameGui.SetActive(isShow);
        }
        if(homeGui)
        {
            homeGui.SetActive(!isShow);
        }
    }    

    public void UpdateTimeCouting(float time)
    {
        if(timeCoutingText)
        {
            timeCoutingText.gameObject.SetActive(true);

            timeCoutingText.text = time.ToString();

            if(time <= 0)
            {
                timeCoutingText.gameObject.SetActive(false);
            }
        }
    }

    public void UpdateScoreCountingText(int score)
    {
        if (scoreCountingText)
        {
            scoreCountingText.text = "Score :" + score.ToString();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        if(pauseDialog)
        {
            pauseDialog.Show(true);
        }
    }
}
