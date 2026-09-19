using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform Player1Paddle; public Transform Player2Paddle; public BallController ballController; public int player1Score = 0; public int player2Score = 0;
    public TextMeshProUGUI textPointsPlayer1; public TextMeshProUGUI textPointsPlayer2;
    void Start()
    {
        ResetGame();
    }
    public void ResetGame()
    {
        Player1Paddle.position = new Vector3(-7f, 0f, 0f);
        Player2Paddle.position = new Vector3(7f, 0f, 0f);
        ballController.ResetBall();
        player1Score = 0; player2Score = 0;
        textPointsPlayer2.text = player2Score.ToString(); textPointsPlayer1.text = player1Score.ToString();
    }
    public void ScorePlayer1()
    {
        player1Score++;
        textPointsPlayer1.text = player1Score.ToString();
    }
    public void ScorePlayer2()
    {
        player2Score++;
        textPointsPlayer2.text = player2Score.ToString();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetGame();
        }
    }

}