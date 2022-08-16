using UnityEngine;
using System.Collections;

public static class GameManager {

    public static int score;
    public static int combo;
    public static int health = 100;
    public static float wind;
    public static bool gameActive;

    public static void AddScore(int addScore)
    {
        score += ((combo / 10) * addScore) + addScore;
        combo++;
    }

    public static void AddHealth(int addHealth)
    {
        health += addHealth;
        Sound sound = GameObject.FindGameObjectWithTag("Sounds").GetComponent<Sound>();
        sound.PlaySound(sound.healthSound, 0);
        if (health > 100) health = 100;       
    }

    public static void DecreaseHealth(int decHealth)
    {
        health -= decHealth;
        combo = 0;
        if (health <= 0) EndGame();
    }

    public static void EndGame()
    {
        PlayerManager.AddScore(score);
        GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().gameIsActive = false;
        gameActive = false;
        MainCanvas mc = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MainCanvas>();
        mc.ShowGameOverPanel();
        PlayerManager.Save();
        if (!PlayerManager.isPaidVersion) GameObject.FindGameObjectWithTag("Ads").GetComponent<MobileAds>().RequestInterstitial();
    }

    public static void AdvanceGame()
    {
        MainCanvas mc = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MainCanvas>();
        mc.HideGameOver();
        mc.HideHighScores();
        mc.ShowMainMenu();
        score = 0;
        combo = 0;
        health = 100;
        PlayerManager.Save();
        MobileAds ma = GameObject.FindGameObjectWithTag("Ads").GetComponent<MobileAds>();
        if (!PlayerManager.isPaidVersion)
        {
            ma.ShowInterstitial();
            ma.ShowBanner();
        }
    }

    public static void ShowHighScores()
    {
        PlayerManager.Load();
        MainCanvas mc = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MainCanvas>();
        mc.HideMainMenu();
        mc.ShowHighScores();
    }

    public static void StartGame()
    {
        gameActive = true;
        health = 100;
        GameObject.FindGameObjectWithTag("Ads").GetComponent<MobileAds>().HideBanner();
        MainCanvas mc = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MainCanvas>();
        mc.HideMainMenu();
        GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().Activate();
    }

}
