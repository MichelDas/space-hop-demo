using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHolder : MonoBehaviour {

    [SerializeField] private GameObject waitingPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private Text scoreText;

    public void Init()
    {
        ActivateWaitingPanel(true);
        ActivateGamePanel(false);
        ActivateGameOverPanel(false);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ActivateWaitingPanel(bool flag)
    {
        waitingPanel.SetActive(flag);
    }

    public void ActivateGamePanel(bool flag)
    {
        gamePanel.SetActive(flag);
    }

    public void ActivateGameOverPanel(bool flag)
    {
        gameOverPanel.SetActive(flag);
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void InitGameOver()
    {
        ActivateGamePanel(false);
        ActivateGameOverPanel(true);
    }

}
