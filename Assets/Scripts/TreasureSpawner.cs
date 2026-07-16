using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{

    [SerializeField] private GameObject treasure;
    private float spawnInterval = 4f;
    private float minY = -4.5f;
    private float maxY = 4.5f;
    private float minX = 10f;
    private float maxX = 15f;
    private float timer;

    private void Start()
    {
        timer = spawnInterval;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnTreasure();
            timer = 0f;
        }
    }

    private void SpawnTreasure()
    {
        if (treasure != null)
        {
            float randomY = Random.Range(minY, maxY);
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
            Instantiate(treasure, spawnPosition, Quaternion.identity);
        }
        else
        {
            return;
        }
    }
}
