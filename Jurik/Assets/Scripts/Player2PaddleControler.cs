using UnityEngine;

public class Player2PaddleControler : MonoBehaviour
{
    public float speed = 5f;
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;
        newPosition.y = Mathf.Clamp(newPosition.y, -4f, 4f);
        transform.position = newPosition;
    }
}
