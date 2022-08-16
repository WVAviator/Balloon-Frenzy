using UnityEngine;
using System.Collections;
using System;

public static class PlayerManager {

    public static int coins;
    public static int[] scores = new int[10] { 0,0,0,0,0,0,0,0,0,0 };
    public static int lastPops;
    public static int totalPops;

    public static bool isPaidVersion;

    public static bool isLoggedIn;

    public static void AddCoins(int amount)
    {
        if (amount <= 0) return;
        coins += amount;
        Sound sound = GameObject.FindGameObjectWithTag("Sounds").GetComponent<Sound>();
        sound.PlaySound(sound.coinSound, 0);
        if (isLoggedIn) GameObject.FindGameObjectWithTag("GP").GetComponent<PlayGamesHandler>().IncrementMoneyAceivement(amount);
    }

    public static void DisableAds()
    {
        isPaidVersion = true;
        MobileAds ma = GameObject.FindGameObjectWithTag("Ads").GetComponent<MobileAds>();
        ma.HideBanner();
        ma.DestroyAdInstances();
    }

    public static void AddPop()
    {
        lastPops++;
    }

    public static void AddScore(int score)
    {
        if (isLoggedIn) GameObject.FindGameObjectWithTag("GP").GetComponent<PlayGamesHandler>().AddScore(score);
        if (isLoggedIn) GameObject.FindGameObjectWithTag("GP").GetComponent<PlayGamesHandler>().IncrementPopAcheivement(lastPops);
        totalPops += lastPops;
        lastPops = 0;

        int[] newScores = new int[11];
        for (int i = 0; i < 10; i++)
        {
            newScores[i] = scores[i];
        }
        newScores[10] = score;
        Array.Sort(newScores, (x, y) => y.CompareTo(x));
        scores = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        for(int i = 0; i < 10; i++)
        {
            scores[i] = newScores[i];
        }

    }

    public static string GetScoresString()
    {
        string scoreString = "";
        for(int i = 0; i < 10; i++)
        {
            scoreString += (i + 1) + ".";
            scoreString += (i < 9) ? "     " : "   ";
            scoreString += ((i < scores.Length) ? scores[i] : 0);
            scoreString += "\n";
        }
        return scoreString;
    }

    public static void SaveScores()
    {
        for(int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetInt("Score" + (i + 1), ((i < 10) ? scores[i] : 0));
        }
    }

    public static void SaveCoins()
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetInt("Pops", totalPops);
    }

    public static void LoadCoins()
    {
        coins = PlayerPrefs.GetInt("Coins");
        totalPops = PlayerPrefs.GetInt("Pops");
    }


    public static void LoadScores()
    {
        for(int i = 0; i < 10; i++)
        {
            scores[i] = PlayerPrefs.GetInt("Score" + (i + 1));
        }
    }

    public static void Load()
    {
        if (!PlayerPrefs.HasKey("Coins")) return;
        LoadCoins();
        LoadScores();
    }

    public static void Save()
    {
        SaveCoins();
        SaveScores();
        PlayerPrefs.Save();
    }
	
}
