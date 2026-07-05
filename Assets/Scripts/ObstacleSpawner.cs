using Unity.Collections;
using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject shortObstaclePrefab;
    public GameObject mediumObstaclePrefab;
    public GameObject longObstaclePrefab;
    public float spawnDistance = 30f;
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
        if (obstaclesPassed >= 20)
        {
            obstaclesPassed = 0;
            SpawnBurst();
        }
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            int randomType = Random.Range(1, 5);

            if (randomType == 1)
            {
                float xlocation = Random.Range(-2f, 2f);
                GameObject obs = Instantiate(longObstaclePrefab, new Vector3(xlocation, 2.19f, transform.position.z), Quaternion.identity);
                obs.transform.localScale = new Vector3(9.478f, 3.392f, 1.3f);
            }
            else if (randomType == 2)
            {
                float xlocation = Random.Range(-3f, 3f);
                float shortX = xlocation + 5f;
                GameObject obs1 = Instantiate(mediumObstaclePrefab, new Vector3(xlocation, 2.19f, transform.position.z), Quaternion.identity);
                obs1.transform.localScale = new Vector3(6.339f, 3.392f, 1.062f);
                GameObject obs2 = Instantiate(shortObstaclePrefab, new Vector3(shortX, 2.19f, transform.position.z), Quaternion.identity);
                obs2.transform.localScale = new Vector3(4.07f, 3.392f, 1.062f);
            }
            else if (randomType == 3)
            {
                float xlocation = Random.Range(-5f, 5f);
                GameObject obs = Instantiate(shortObstaclePrefab, new Vector3(xlocation, 2.19f, transform.position.z), Quaternion.identity);
                obs.transform.localScale = new Vector3(4.07f, 3.392f, 1.062f);
            }
            else
            {
                float xlocation = Random.Range(-3f, 3f);
                GameObject obs = Instantiate(mediumObstaclePrefab, new Vector3(xlocation, 2.19f, transform.position.z), Quaternion.identity);
                obs.transform.localScale = new Vector3(6.339f, 3.392f, 1.062f);
            }

            yield return new WaitForSeconds(2f);
        }
    }

    void SpawnBurst()
    {
        for (int i = 1; i <= 20; i++)
        {
            float spawnZ = transform.position.z + (i * 30f);
            float xlocation = Random.Range(-5f, 5f);
            GameObject obs = Instantiate(shortObstaclePrefab, new Vector3(xlocation, 2.19f, spawnZ), Quaternion.identity);
            obs.transform.localScale = new Vector3(4.07f, 3.392f, 1.062f);
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
