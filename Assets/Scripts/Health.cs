using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public EnemyHealthBar healthBar; // Tham chiếu tới thanh HP của Enemy

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth, maxHealth); // Cập nhật giá trị thanh HP
        }
    }

    private void Die()
    {
        // Xử lý khi quái chết
        Destroy(gameObject);
    }
}
