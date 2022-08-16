using UnityEngine;
using System.Collections;

public class MainCanvas : MonoBehaviour {

    public GameObject gameOverPanel;
    public GameObject mainMenuPanel;
    public GameObject highScoresPanel;

    void Start()
    {
        gameOverPanel.SetActive(false);
        Sound sound = GameObject.FindGameObjectWithTag("Sounds").GetComponent<Sound>();
    }

    public void HideGameOver()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        gameOverPanel.transform.FindChild("CoinsText").GetComponent<BonusCoinsText>().Spin();
    }

    public void HideMainMenu()
    {
        mainMenuPanel.SetActive(false);
    }

    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
    }

    public void ShowHighScores()
    {
        highScoresPanel.SetActive(true);
    }

    public void HideHighScores()
    {
        highScoresPanel.SetActive(false);
    }

    public bool AllWindowsHidden()
    {
        return (!highScoresPanel.activeSelf && !mainMenuPanel.activeSelf && !gameOverPanel.activeSelf);
    }
}
