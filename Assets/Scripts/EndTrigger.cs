using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerMovement movement;
    public GameObject LevelCompleteUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.CompleteLevel();
            movement.enabled = false;
            LevelCompleteUI.gameObject.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}
