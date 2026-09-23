using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb; public GameManager gameManager;
    private Vector2 startingVelocity = new Vector2(5f, 5f);
    public void ResetBall()
    {
        transform.position = Vector3.zero;
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = startingVelocity;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = rb.linearVelocity;

            newVelocity.y = -newVelocity.y;
            rb.linearVelocity = newVelocity;
        }
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            rb.linearVelocity = new Vector2(-rb.linearVelocity.x, rb.linearVelocity.y);
        }
        if (collision.gameObject.CompareTag("WallPlayer1"))
        {
            gameManager.ScorePlayer1();
            ResetBall();
        }
        if (collision.gameObject.CompareTag("WallPlayer2"))
        {
            gameManager.ScorePlayer2();
            ResetBall();
        }
    }

}
