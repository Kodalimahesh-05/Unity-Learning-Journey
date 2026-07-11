using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public Vector3 offset = new Vector3(0, 5, -10);
    public Vector3 shakeOffset = Vector3.zero;

    void LateUpdate()
    {
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        transform.position += shakeOffset;
    }
}
