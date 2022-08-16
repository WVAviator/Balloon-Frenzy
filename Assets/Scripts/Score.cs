using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    int score;
    Text text;

    void Start()
    {
        score = GameManager.score;
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (score == GameManager.score) return;
        score = GameManager.score;
        text.text = "Score: " + score.ToString("D8");
    }
}
