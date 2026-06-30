using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scorecount;

    void Update()
    {
        scorecount.text = player.position.z.ToString("0");
    }
}
