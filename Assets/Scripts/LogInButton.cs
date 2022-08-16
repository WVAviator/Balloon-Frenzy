using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogInButton : MonoBehaviour {

    public Text text;
    PlayGamesHandler pgh;

    void Start()
    {
        pgh = GameObject.FindGameObjectWithTag("GP").GetComponent<PlayGamesHandler>();
    }

    void Update()
    {
        if (!PlayerManager.isLoggedIn)
        {
            text.text = "Log In";
            text.fontSize = 40;
        }
        if (PlayerManager.isLoggedIn)
        {
            text.text = "Acheivements";
            text.fontSize = 28;
        }
    }

    public void Press()
    {
        if (PlayerManager.isLoggedIn) pgh.ShowAcheivements();
        if (!PlayerManager.isLoggedIn) pgh.LogIn();
    }
}
