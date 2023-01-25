using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }
    public List<Brick> bricks = new List<Brick>();
    
    public int level=1;
    public int score=0;
    public int lives=3;

    public Action onScoreChange;
    public Action onLivesChange;

    private void Awake()
    {
        ball = FindObjectOfType<Ball>();
        paddle = FindObjectOfType<Paddle>();
        Brick[] brickArray = FindObjectsOfType<Brick>();
        
        

        foreach (Brick brick in brickArray)
            if(!brick.unbreakable)
                bricks.Add(brick);
    }

    private void Start()
    {
        ResetGame();
    }

    private void ResetLevel()
    {
        ball.ResetBall();
        paddle.ResetPaddle();

        for (int i = 0; i < bricks.Count; i++)
            bricks[i].ResetBrick();

        // foreach (Brick brick in bricks)
        //     brick.ResetBrick();
        
    }

    private void ResetGame()
    {
        score = 0;
        lives = 3;
    }
    
    private void GameOver()
    {
        ResetGame();
    }

    public void Dead()
    {
        lives--;

        if (lives > 0)
        {
            score = 0;
        }
        else
        {
            GameOver();
        }
    }

    public void Hit(Brick brick)
    {
        score += brick.points;
        if (Cleared())
        {
            Debug.Log("GAME CLEAR");
            ResetGame();
        }
    }
    private bool Cleared()
    {
        return bricks.Count == 0;
    }
}    