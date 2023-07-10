using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI counter;
    [HideInInspector] public int score = 0;

    LivesCounter lives;
    int extraLife;

    private void Start()
    {
        lives = FindObjectOfType<LivesCounter>();
    }

    void FixedUpdate()
    {
        ShowScore();
    }

    public void ShowScore()
    {
        counter.text = score.ToString();
    }

    public void AddScore(int scoreNum)
    {
        score += scoreNum;
        extraLife += scoreNum;

        if (extraLife >= 1000000)
        {
            lives.AddLives(1);
            extraLife -= 1000000;
        }
    }
}
