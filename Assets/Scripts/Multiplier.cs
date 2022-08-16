using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Multiplier : MonoBehaviour {

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = "x" + ((GameManager.combo / 10) + 1);
    }
}
