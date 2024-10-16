using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;            // Tốc độ di chuyển của quái vật
    private Transform player;           // Tham chiếu đến đối tượng người chơi

    private Rigidbody2D rb;             // Thành phần Rigidbody2D của quái vật

    void Start()
    {
        // Tìm người chơi theo tag "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Lấy Rigidbody2D từ quái vật để tương tác vật lý
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            // Di chuyển quái vật về phía người chơi
            Vector2 direction = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Xử lý va chạm với người chơi (xô đẩy)
            Vector2 pushDirection = collision.transform.position - transform.position;
            rb.AddForce(-pushDirection.normalized * 100f); // Tạo lực xô đẩy khi va chạm
        }
    }
}
