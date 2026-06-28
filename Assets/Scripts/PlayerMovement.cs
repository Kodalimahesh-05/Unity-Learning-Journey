using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Player is moving forward");
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Player is moving backward");
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Player is moving left");
            transform.position += Vector3.left * speed * Time.deltaTime;   
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Player is moving right");
            transform.position += Vector3.right * speed * Time.deltaTime;
        }    
    }
}
