using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Score Text
    [SerializeField] TextMeshProUGUI scoreText;

    int score = 0;
    readonly int coinScore = 10;

    public void UpdateScore(){
        // Update score
        score += coinScore;
        scoreText.text = "Score: " + score.ToString("D3");
    }
}
