using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHP = 100;          // HP tối đa
    [SerializeField] private int currentHP;           // HP hiện tại

    // Sự kiện khi đối tượng bị tiêu diệt
    public delegate void OnDeath();
    public event OnDeath onDeath;

    void Start()
    {
        // Khởi tạo HP hiện tại bằng HP tối đa
        currentHP = maxHP;
    }

    // Hàm nhận sát thương
    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        // Kiểm tra HP có <= 0 không
        if (currentHP <= 0)
        {
            if (onDeath != null)
            {
                onDeath.Invoke();  // Gọi sự kiện tiêu diệt nếu đã được đăng ký
            }
            Destroy(gameObject);   // Tiêu diệt đối tượng nếu hết máu
        }
    }

    // Hàm hồi máu (nếu cần)
    public void Heal(int amount)
    {
        currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);
    }
}
