using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScoreText : MonoBehaviour {

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = "FinalScore: " + GameManager.score;
	}

}
