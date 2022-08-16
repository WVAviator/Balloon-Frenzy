using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class PlayGamesHandler : MonoBehaviour {

	void Start()
    {
        PlayGamesPlatform.Activate();
        LogIn();
    }

    public void LogOut()
    {
        PlayGamesPlatform.Instance.SignOut();
        PlayerManager.isLoggedIn = false;
    }

    public void ShowAcheivements()
    {
        Social.ShowAchievementsUI();
    }

    public void LogIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            PlayerManager.isLoggedIn = success;
        });
    }

    public void IncrementMoneyAceivement(int money)
    {
        PlayGamesPlatform.Instance.IncrementAchievement("CgkI8aO6ipscEAIQBg", money, (bool success) =>
        {

        });
    }

    public void IncrementPopAcheivement(int pops)
    {
        PlayGamesPlatform.Instance.IncrementAchievement("CgkI8aO6ipscEAIQBw", pops, (bool success) =>
        {

        });
    }

    public void ScoreAcheivement(int score)
    {
        if(score >= 5000) Social.ReportProgress("CgkI8aO6ipscEAIQAw", 100.0f, (bool success) => {
            
        });
        if (score >= 10000) Social.ReportProgress("CgkI8aO6ipscEAIQBA", 100.0f, (bool success) => {

        });
        if (score >= 20000) Social.ReportProgress("CgkI8aO6ipscEAIQBQ", 100.0f, (bool success) => {

        });
    }

    public void AddScore(int score)
    {
        ScoreAcheivement(score);
        Social.ReportScore(score, "CgkI8aO6ipscEAIQAA", (bool success) =>
        {

        });
    }

    public void DisplayLeaderboard()
    {
        if (!PlayerManager.isLoggedIn)
        {
            LogIn();
            return;
        }
        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI8aO6ipscEAIQAA");
    }
}
