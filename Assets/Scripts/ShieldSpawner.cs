using UnityEngine;

public class ShieldSpawner : MonoBehaviour
{
    public GameObject shieldPrefab;
    public float spawnInterval = 10f;
    public Transform player;

    void Start()
    {
        InvokeRepeating("SpawnShield", spawnInterval, spawnInterval); 
    }

    void SpawnShield()
    {
        float randomX = Random.Range(-4f, 4f);
        Vector3 spawnPos = new Vector3(randomX, 1.47f, player.position.z + 30f);
        Instantiate(shieldPrefab, spawnPos, Quaternion.identity);
    }
}