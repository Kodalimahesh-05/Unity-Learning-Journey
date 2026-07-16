using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    int health = 180;
    bool isDead = false;
    
    void Start()
    {
        Debug.Log("Hi I am Kodali Mahesh. I need to be a Game developer by 2028");
        Debug.Log("Player Health: " +health);
        
    }

    void Damage(int damage)
    {
        if (isDead)
        {
            Debug.Log("Player is already dead. Cannot take more damage.");
            return;
        }
        health = health - damage;
        health = Mathf.Clamp(health, 0, 180);
        Debug.Log("Health after damage:" +health);
        if (health == 0)
        {
            isDead = true;
            Debug.Log("Player is Dead");
        }
    }

    void Heal(int HealAmount)
    {
        if (isDead)
        {
            Debug.Log("Player is dead and cannot heal now. RIP");
            return;
        }
        else
        {
            health = health + HealAmount;
            health = Mathf.Clamp(health, 0 , 180);
            Debug.Log("Health after heal :" + health);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Damage(50);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(20);
        }
    }
}