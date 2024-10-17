using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f; // Thời gian tồn tại của viên đạn

    private void Start()
    {
        Destroy(gameObject, lifetime); // Hủy viên đạn sau khi nó tồn tại đủ lâu
    }

    void Update()
    {
        // Di chuyển viên đạn theo hướng của nó
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra xem đối tượng bị va chạm có Tag là "Enemy" hay không
        if (collision.CompareTag("Enemy"))
        {
            // Hủy đạn sau khi va chạm với quái vật
            Destroy(gameObject);
        }
    }
}
