using UnityEngine;
using UnityEngine.UI;

public class ScroeManager : MonoBehaviour
{
    public static ScroeManager instance;
    public Text scoreText;
    private int score = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }
}
