using UnityEngine;

public class ObstacleDestroy : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player.transform.position.z > transform.position.z + 30f)
        {
            ObstacleSpawner.instance.ObstaclePassed();
            Destroy(gameObject);
        }
    }
}