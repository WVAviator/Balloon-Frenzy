using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinCount : MonoBehaviour {

    Text text;
    int count;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (count == PlayerManager.coins) return;
        count = PlayerManager.coins;
        text.text = "x" + count;
    }

}
