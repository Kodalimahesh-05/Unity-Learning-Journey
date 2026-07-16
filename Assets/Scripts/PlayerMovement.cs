using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float Forwardspeed = 2000f;
    public float sidewayspeed = 500f;
    public float speed = 5f;
    void FixedUpdate()
    {
        rb.AddForce(0, 0, Forwardspeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-sidewayspeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            RotatePlayerleft(-1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(sidewayspeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            RotatePlayerright(1);
        }    
        if (rb.position.y < -5f)
        {
            FindAnyObjectByType<GameManager>().EndGame();
        }
    }

    void RotatePlayerleft(int direction)
    {
        float rotationAmount = direction * speed * Time.deltaTime;
        transform.Rotate(0, rotationAmount, 3);
    }

    void RotatePlayerright(int direction)
    {
        float rotationAmount = direction * speed * Time.deltaTime;
        transform.Rotate(0, rotationAmount, -3);
    }
}
