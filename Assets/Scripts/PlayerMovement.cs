using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển của nhân vật
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        // Lấy component Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Lấy input từ người chơi (bàn phím)
        movement.x = Input.GetAxisRaw("Horizontal"); // Phím A, D hoặc phím mũi tên trái, phải
        movement.y = Input.GetAxisRaw("Vertical");   // Phím W, S hoặc phím mũi tên lên, xuống
    }

    void FixedUpdate()
    {
        // Di chuyển nhân vật dựa trên input và tốc độ di chuyển
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
