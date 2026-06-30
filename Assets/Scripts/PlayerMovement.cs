using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float Forwardspeed = 2000f;
    public float sidewayspeed = 500f;
    public float speed = 5f;
    void Update()
    {
        rb.AddForce(0, 0, Forwardspeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-sidewayspeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(sidewayspeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }    
    }
}
