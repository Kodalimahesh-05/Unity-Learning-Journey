using UnityEngine;

public class AsteroidFall : MonoBehaviour
{
    public float fallForce = 500f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        Vector3 fallDirection = new Vector3(randomX, -1f, randomZ);
        rb.AddForce(fallDirection * fallForce);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            CameraShake shake = Camera.main.GetComponent<CameraShake>();
            if (shake != null)
            {
                StartCoroutine(shake.Shake());
            }
        }
    }
}