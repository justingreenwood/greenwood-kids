using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<GameObject> TargetPrefabs;
    public int TargetCount = 20;
    private System.Random random = new System.Random();
    public int BallsPerGame = 5;
    public bool GameOver = true;
    private int BallsLeft;
    private int Score;
    public Button PlayButton;
    public Text ScoreText;
    public Text BallsLeftText;

    void Awake()
    {        
        for (int i = 0; i < TargetCount; i++)
        {
            Instantiate(TargetPrefabs[random.Next(0, 3)]);
        }
    }

    private void Update()
    {
        ScoreText.text = $"Score: {Score}";
        BallsLeftText.text = $"Balls Left: {BallsLeft}";
        if(GameOver == true)
        {
            PlayButton.gameObject.SetActive(true);
        }
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        GameOver = false;
        BallsLeft = BallsPerGame;
        Score = 0;
        PlayButton.gameObject.SetActive(false);
    }

    public void PlayerScored()
    {
        Score++;
        Instantiate(TargetPrefabs[random.Next(0, 3)]);
    }

    public void BallLost()
    {
        BallsLeft--;
        if(BallsLeft <= 0)
        {
            GameOver = true;
        }
    }
}
