using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public BackgroundScript[] bck;

    public GameObject[] planets;

    [SerializeField] private GameObject reachEffect;

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    public int score;

    [SerializeField] private GameObject rocket;

    public enum GameState
    {
        NotStarted,
        running,
        gameOver
    }

    public GameState gameState;

    public UIHolder uiHolder;
    private bool canReplaceBlock;
	// Use this for initialization
	void Start () {
        instance = this;
        rocket = GameObject.FindGameObjectWithTag("Player");
        uiHolder.Init();
        canReplaceBlock = true;

	}
	
	// Update is called once per frame
	void Update () {
		switch(gameState)
        {
            case GameState.NotStarted:
                WaitForGameStart();
                break;
            case GameState.running:
                FireRocket();
                break;
            case GameState.gameOver:
                break;
        }
	}

    public void ReplaceBlocks()
    {
        if (canReplaceBlock)
        {
            canReplaceBlock = false;
            BackgroundScript element = bck[2];
            bck[2] = bck[1];
            bck[1] = bck[0];
            bck[0] = element;
            bck[0].transform.position = bck[1].nextPosition.transform.position;
            Invoke("enableReplace", 4);
        }
    }

    private void enableReplace()
    {
        canReplaceBlock = true;
    }

    public void WaitForGameStart()
    {
        if(Input.GetMouseButtonDown(0))
        {
            gameState = GameState.running;
            rocket.GetComponent<RocketScript>().GoToMove();
            uiHolder.ActivateGamePanel(true);
            uiHolder.ActivateWaitingPanel(false);
            uiHolder.UpdateScoreText(0);
        }
    }

    public bool getInput;

    public void FireRocket()
    {
        if (Input.GetMouseButtonDown(0) && getInput == true)
        {
            getInput = false;
            rocket.GetComponent<RocketScript>().GoToMove();
        }
    }

    public GameObject GetPlanet()
    {
        int indx = Random.Range(0, planets.Length);

        while(planets[indx].activeInHierarchy)
        {
            indx = Random.Range(0, planets.Length);
        }
        uiHolder.UpdateScoreText(++score);
        return planets[indx];
    }

    public void GotoGameOver()
    {
        gameState = GameState.gameOver;
        uiHolder.InitGameOver();
        rocket.SetActive(false);
    }

    public void showReachEffect(Vector3 position)
    {
        reachEffect.transform.position = position;
        reachEffect.SetActive(true);
    }
}
