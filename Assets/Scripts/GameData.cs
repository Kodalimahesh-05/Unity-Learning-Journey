using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;
    public int currentScore;
    public float forwardspeed;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            forwardspeed = 2000f;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}