using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float minSpawnTime;
    public float maxSpawnTime;
    public GameObject[] ObstaclePbs;
    public GameObject player;
    public BGLoop bgloop;
    public bool isGameOver;
    public bool isGamePlaying;

    private int m_score;

    public int Score { get => m_score; set => m_score = value; }

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public override void Start()
    {
        base.Start();

        GameGUIManager.Ins.ShowGameGUI(false);

        GameGUIManager.Ins.UpdateScoreCountingText(m_score);
    }

    public void PlayGame()
    {
        GameGUIManager.Ins.homeGui.SetActive(false);
        StartCoroutine(CoutingDown());
    }

    IEnumerator CoutingDown()
    {
        float time = 3f;

        GameGUIManager.Ins.UpdateTimeCouting(time);

        while(time > 0)
        {
            yield return new WaitForSeconds(1f);
            time--;
            GameGUIManager.Ins.UpdateTimeCouting(time);
        }

        isGamePlaying = true;

        if(player)
        {
            player.SetActive(true);
        }
        if(bgloop)
        {
            bgloop.isStart = true;
        }

        StartCoroutine(SpawnOpstacle());
        GameGUIManager.Ins.ShowGameGUI(true);
    }

    IEnumerator SpawnOpstacle()
    {
        while (!isGameOver)
        {
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);

            yield return new WaitForSeconds(spawnTime);

            if(ObstaclePbs != null && ObstaclePbs.Length > 0)
            {
                int obIdx = Random.Range(0,ObstaclePbs.Length);

                GameObject obstacle = ObstaclePbs[obIdx];

                if(obstacle != null)
                {
                    Vector3 spawnPos = new Vector3(
                        Random.Range(-1.4f, 1.4f), 8f, 0f);

                    Instantiate(obstacle, spawnPos, Quaternion.identity);
                }
            }
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        isGamePlaying = false;
        Prefs.bestScore = m_score;
        GameGUIManager.Ins.gameOverDialog.Show(true);
    }
}
