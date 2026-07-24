using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    public bool isCollected = false; 
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (playerTransform != null && playerTransform.position.z > transform.position.z + 30f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")) 
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>(); 
            if (playerMovement != null) 
            {
                playerMovement.ActivateShield();
                
                isCollected = true;
                Destroy(gameObject);
            }
        }
    }
}