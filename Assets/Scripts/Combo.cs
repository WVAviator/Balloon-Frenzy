using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Combo : MonoBehaviour {

    int combo;
    Text text;

    void Start()
    {
        combo = GameManager.combo;
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (combo == GameManager.combo) return;
        combo = GameManager.combo;
        text.text = "Combo: " + combo.ToString();
    }
}
