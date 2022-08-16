using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject removeAdsButton;

    void Start()
    {
        PlayerManager.Load();
    }

    void Update()
    {
        HandleRemoveAdsButton();
    }

    void HandleRemoveAdsButton()
    {
        if (!PlayerManager.isPaidVersion) return;
        removeAdsButton.SetActive(!PlayerManager.isPaidVersion);
    }

	public void StartGame()
    {
        GameManager.StartGame();
    }

    public void HighScores()
    {
        GameManager.ShowHighScores();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
