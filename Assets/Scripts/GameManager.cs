using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float levelLoadDelay = 2f;
    public PlayerMovement movement;
    public GameObject GameOverText;
    public GameObject LevelCompleteUI;


    public void CompleteLevel()
    {
        LevelCompleteUI.SetActive(true);
        movement.enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over!");
            movement.enabled = false;
            GameOverText.SetActive(true);
            Invoke("Restart", 3f);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
