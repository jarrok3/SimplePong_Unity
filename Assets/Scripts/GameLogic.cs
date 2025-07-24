using System;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameLogic : MonoBehaviour
{
    [SerializeField]
    GameObject ball;
    [SerializeField]
    GameObject player1;
    [SerializeField]
    GameObject player2;
    [SerializeField]
    TMP_Text field1;
    [SerializeField]
    TMP_Text field2;
    [SerializeField]
    GameObject winOverlay;

    // Could upgrade with dynamic assign directly from gameobjects' properties
    Vector2 pos_start_ball = new Vector2(0, 0);
    Vector2 pos_start_player1 = new Vector2(-9, 0);
    Vector2 pos_start_player2 = new Vector2(9, 0);

    int pointsPlayer1 = 0;
    int pointsPlayer2 = 0;

    float direction = 0f;
    float speed = 5f;

    Rigidbody2D rb;

    private void MovementBall()
    {
        if (UnityEngine.Random.value < 0.5f)
        {
            direction = 1f;
        }
        else
        {
            direction = -1f;
        }

        float randomAdjustment = UnityEngine.Random.value;

        rb.linearVelocity = new Vector2(direction * speed, direction * speed + randomAdjustment);
    }

    private void ResetPositions()
    {
        ball.transform.position = pos_start_ball;
        player1.transform.position = pos_start_player1;
        player2.transform.position = pos_start_player2;
    }

    public void ResetGame(bool who_wins)
    {
        if (who_wins)
        {
            pointsPlayer1 += 1;
            field1.text = pointsPlayer1.ToString();
        }
        else
        {
            pointsPlayer2 += 1;
            field2.text = pointsPlayer2.ToString();
        }

        if (pointsPlayer1 == 1)
        {
            ShowWinner(true);
            return;
        }
        else if (pointsPlayer2 == 1)
        {
            ShowWinner(false);
            return;
        }

            Debug.Log("Game logic reset...");

        ResetPositions();
        MovementBall();
    }

    private void StopGame()
    {
        Debug.Log("STOP GAME");
        ResetPositions();
        rb.linearVelocity = Vector2.zero;
    }

    private void ShowWinner(bool player1won)
    {
        string winner = "";
        if (!player1won)
            winner = "\nplayer1";
        else winner = "\nplayer2";

        StopGame();
        winOverlay.SetActive(true);
        winOverlay.GetComponentInChildren<TMP_Text>().text += winner;
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winOverlay.SetActive(false);

        rb = ball.GetComponent<Rigidbody2D>();

        MovementBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
