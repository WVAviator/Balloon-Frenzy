using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

	void Update()
    {
        GetComponent<Text>().text = PlayerManager.GetScoresString();
    }

    public void Back()
    {
        GameManager.AdvanceGame();
    }
}
