using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage = 25;  // Sát thương của đối tượng (ví dụ: đạn)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);  // Gây sát thương lên đối tượng có Health
        }

        // Tùy vào đối tượng, có thể tự hủy sau khi va chạm (đối với đạn)
        if (gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
