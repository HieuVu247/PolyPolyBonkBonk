using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Prefab quái vật
    public float spawnInterval = 2f;  // Khoảng thời gian giữa mỗi lần sinh quái
    public float spawnDistance = 10f; // Khoảng cách tối thiểu giữa camera và vị trí sinh quái

    private Transform player;        // Tham chiếu đến người chơi

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // Lặp lại việc sinh quái theo thời gian
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Tính vị trí spawn ngẫu nhiên ngoài tầm nhìn của camera
        Vector2 spawnPos = GetRandomSpawnPosition();

        // Sinh quái vật tại vị trí spawn
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    // Hàm lấy vị trí ngẫu nhiên ngoài ranh giới camera
    Vector2 GetRandomSpawnPosition()
    {
        // Lấy vị trí của camera và giới hạn của nó
        Vector2 playerPos = player.position;
        Camera cam = Camera.main;
        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        // Tính toán vùng spawn ngoài camera
        float spawnX = Random.Range(playerPos.x - camWidth / 2 - spawnDistance, playerPos.x + camWidth / 2 + spawnDistance);
        float spawnY = Random.Range(playerPos.y - camHeight / 2 - spawnDistance, playerPos.y + camHeight / 2 + spawnDistance);

        // Đảm bảo quái vật spawn bên ngoài vùng nhìn thấy
        if (Mathf.Abs(spawnX - playerPos.x) < camWidth / 2) spawnX = playerPos.x + Mathf.Sign(spawnX - playerPos.x) * (camWidth / 2 + spawnDistance);
        if (Mathf.Abs(spawnY - playerPos.y) < camHeight / 2) spawnY = playerPos.y + Mathf.Sign(spawnY - playerPos.y) * (camHeight / 2 + spawnDistance);

        return new Vector2(spawnX, spawnY);
    }
}
