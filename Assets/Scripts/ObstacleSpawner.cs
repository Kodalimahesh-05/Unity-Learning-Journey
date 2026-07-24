using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnDistance = 20f;
    public GameObject player;
    public static ObstacleSpawner instance;
    private int obstaclesPassed = 0;
    void Start()
    {
        SpawnBurst();
        StartCoroutine(SpawnObstacles());
    }
    

    void Awake()
    {   
        instance = this;
    }

    public void ObstaclePassed()
    {
        obstaclesPassed++;
        if (obstaclesPassed >= 25)
        {
            obstaclesPassed = 0;
            SpawnBurst();
        }
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float xlocation = Random.Range(-1f, 1f);
            Instantiate(asteroidPrefab, new Vector3(xlocation, 30f, transform.position.z + 35f), Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }
    }

    void SpawnBurst()
    {
        for (int i = 1; i <= 20; i++)
        {
            float spawnZ = transform.position.z + (i * 25f) + 35f;
            float xlocation = Random.Range(-1f, 1f);
            GameObject obs = Instantiate(asteroidPrefab, new Vector3(xlocation, 30f, spawnZ), Quaternion.identity);
        }
    }

    void Update()
    {
        transform.position = new Vector3(
        transform.position.x,
        transform.position.y,
        player.transform.position.z + spawnDistance
        );
    }

}