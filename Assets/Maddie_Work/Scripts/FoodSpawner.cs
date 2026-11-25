using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] foodPrefabs;
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private float minX = -8f;
    [SerializeField] private float maxX = 8f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnFood();
        }
    }

    void SpawnFood()
    {
        if (foodPrefabs.Length == 0) return;

        int index = Random.Range(0, foodPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);
        Instantiate(foodPrefabs[index], spawnPos, Quaternion.identity);
    }
}