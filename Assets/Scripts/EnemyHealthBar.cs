using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider healthSlider;  // Thanh slider để hiển thị HP
    public Vector3 offset;       // Vị trí offset để thanh HP không nằm ngay trên đầu Enemy

    private Transform enemyTransform; // Transform của Enemy mà thanh HP gắn với

    private void Start()
    {
        enemyTransform = transform.parent; // Enemy sẽ là Parent của thanh HP
    }

    private void Update()
    {
        // Cập nhật vị trí của thanh HP dựa trên vị trí của Enemy
        if (enemyTransform != null)
        {
            transform.position = enemyTransform.position + offset;
        }
    }

    // Hàm để cập nhật giá trị thanh HP
    public void SetHealth(float currentHealth, float maxHealth)
    {
        healthSlider.value = currentHealth / maxHealth; // Cập nhật tỉ lệ HP
    }
}
