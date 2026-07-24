using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.3f;
    public float shakeMagnitude = 0.2f;

    public IEnumerator Shake()
    {
        CameraFollow cameraFollow = Camera.main.GetComponent<CameraFollow>();
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float xOffset = Random.Range(-1f, 1f) * shakeMagnitude;
            float yOffset = Random.Range(-1f, 1f) * shakeMagnitude;
            cameraFollow.shakeOffset = new Vector3(xOffset, yOffset, 0);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        cameraFollow.shakeOffset = Vector3.zero;
    }
}