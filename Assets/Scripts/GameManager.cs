using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 3f;
    public PlayerMovement movement;
    public TextMeshProUGUI GameOverText;
    public GameObject LevelCompleteUI;

    public void CompleteLevel()
    {
        LevelCompleteUI.SetActive(true);
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over!");
            movement.enabled = false;
            GameOverText.gameObject.SetActive(true);
            Invoke("Restart", 3f);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
