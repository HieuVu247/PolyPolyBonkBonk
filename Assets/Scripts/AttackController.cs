using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public GameObject bulletPrefab;  // Prefab của viên đạn
    public Transform firePoint;      // Điểm mà đạn sẽ bắn ra
    public float fireRate = 0.5f;    // Tốc độ bắn (cooldown)
    private float nextFireTime = 0f;

    public bool autoAim = true;      // Mặc định là auto-aim
    public float aimRadius = 10f;    // Bán kính tìm kiếm mục tiêu gần nhất

    void Update()
    {
        // Nhấn chuột trái để chuyển đổi giữa auto-aim và manual aim
        if (Input.GetMouseButtonDown(0))
        {
            autoAim = !autoAim; // Chuyển đổi chế độ
        }

        // Tự động bắn khi đến thời điểm cooldown
        if (Time.time >= nextFireTime)
        {
            if (autoAim)
            {
                // Auto-aim: tìm mục tiêu gần nhất
                GameObject nearestTarget = FindNearestEnemy();
                if (nearestTarget != null)
                {
                    AimAndShoot(nearestTarget.transform.position);
                }
            }
            else
            {
                // Manual aim: bắn theo hướng chuột
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                AimAndShoot(mousePosition);
            }

            nextFireTime = Time.time + fireRate; // Cài lại cooldown cho lần bắn tiếp theo
        }
    }

    void AimAndShoot(Vector2 targetPosition)
    {
        // Xoay firePoint về hướng mục tiêu
        Vector2 direction = (targetPosition - (Vector2)firePoint.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0, 0, angle - 90f); // Xoay điểm bắn

        // Bắn đạn
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Bỏ qua va chạm giữa đạn và người chơi
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());

    }

    GameObject FindNearestEnemy()
    {
        // Tìm kẻ địch gần nhất
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearest = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance && distance <= aimRadius)
            {
                nearest = enemy;
                minDistance = distance;
            }
        }

        return nearest;
    }
}
