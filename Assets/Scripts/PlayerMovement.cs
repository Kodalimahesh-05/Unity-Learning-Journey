using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    
    public float forwardspeed = 2000f;
    public float maxForwardSpeed = 5000f;
    public float speedIncreaseRate = 50f;
    public float sidewayspeed = 500f;
    
    public float tiltAmount = 15f;
    public float tiltSpeed = 5f;
    
    public bool hasShield = false;
    public GameObject shieldVisual; 
    public float shieldDuration = 7f;
    public float blinkDuration = 2f; 
    public float blinkInterval = 0.15f;

    private Coroutine shieldCoroutine;
    private bool isInvincible = false;

    void Update()
    {
        if (GameData.Instance.forwardspeed < maxForwardSpeed)
        {
            GameData.Instance.forwardspeed += speedIncreaseRate * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, GameData.Instance.forwardspeed * Time.deltaTime);

        float targetTiltZ = 0f;
        bool isMovingLeft = false;
        bool isMovingRight = false;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2f)
            {
                isMovingLeft = true;
            }
            else if (touch.position.x > Screen.width / 2f)
            {
                isMovingRight = true;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.A)) isMovingLeft = true;
            if (Input.GetKey(KeyCode.D)) isMovingRight = true;
        }

        if (isMovingLeft)
        {
            rb.AddForce(-sidewayspeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            targetTiltZ = tiltAmount; 
        }
        else if (isMovingRight)
        {
            rb.AddForce(sidewayspeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            targetTiltZ = -tiltAmount; 
        }

        Quaternion targetRotation = Quaternion.Euler(0, transform.eulerAngles.y, targetTiltZ);
        Quaternion smoothedRotation = Quaternion.Slerp(rb.rotation, targetRotation, tiltSpeed * Time.deltaTime);
        
        rb.MoveRotation(smoothedRotation);

        if (rb.position.y < -5f)
        {
            FindAnyObjectByType<GameManager>().EndGame();
        }
    }

    

    public void ActivateShield()
    {
        if (!hasShield)
        {
            shieldCoroutine = StartCoroutine(ShieldRoutine());
        }
    }

    public void DeactivateShield()
    {
        if (shieldCoroutine != null)
        {
            StopCoroutine(shieldCoroutine);
        }

        hasShield = false;
        
        if (shieldVisual != null)
        {
            shieldVisual.SetActive(false);
        }
    }

    private IEnumerator ShieldRoutine()
    {
        hasShield = true;
        
        if (shieldVisual != null)
        {
            shieldVisual.SetActive(true);
        }

        yield return new WaitForSeconds(shieldDuration - blinkDuration);

        float blinkTimer = blinkDuration;
        while (blinkTimer > 0)
        {
            if (shieldVisual != null)
            {
                shieldVisual.SetActive(!shieldVisual.activeSelf);
            }
            
            yield return new WaitForSeconds(blinkInterval);
            blinkTimer -= blinkInterval;
        }
        DeactivateShield();
    }

    private IEnumerator BreakShieldSafely()
    {
        isInvincible = true;
        DeactivateShield();
        
        // Gives the player a quarter-second of safety from double-hits
        yield return new WaitForSeconds(0.25f); 
        isInvincible = false;
    }
}