using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BonusCoinsText : MonoBehaviour {

    Text text;

    public void Spin()
    {
        text = GetComponent<Text>();
        StartCoroutine("Cycle");
    }

    IEnumerator Cycle()
    {
        for (int i = 0; i < 100; i++)
        {
            text.text = "x" + Random.Range(0, 20);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        int coinsAdded = (GameManager.score / 100);
        text.text = "x" + coinsAdded;
        PlayerManager.AddCoins(coinsAdded);
    }
}
