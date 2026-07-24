using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            if (movement.hasShield)
            {
                movement.DeactivateShield(); 
                Destroy(collisionInfo.gameObject);
                return;
            }
            
            movement.enabled = false;
            FindAnyObjectByType<GameManager>().EndGame();
        }
    }
}