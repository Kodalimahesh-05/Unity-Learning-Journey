using TMPro;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scorecount;

    private float startOffset;

    void Start()
    {
        startOffset = GameData.Instance.currentScore - player.position.z;
    }

    void Update()
    {
        GameData.Instance.currentScore = Mathf.RoundToInt(startOffset + player.position.z);
        scorecount.text = GameData.Instance.currentScore.ToString();
    }
}