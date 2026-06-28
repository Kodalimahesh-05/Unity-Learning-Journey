using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public Vector3 offset = new Vector3(0, 5, -10);

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, speed * Time.deltaTime);
    }
}
