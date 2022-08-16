using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BasePanel : MonoBehaviour {

    public Text timer;
    public float timeRemaining;

    public RectTransform spreadShotRect;
    public RectTransform laserShotRect;
    public RectTransform spikesRect;
    public RectTransform fanRect;

    public int spreadShotCost = 75;
    public int laserShotCost = 50;
    public int spikesCost = 30;
    public int fanCost = 100;

    public bool powerupActive;

    ShotHandler sh;

    void Start()
    {
        sh = GameObject.FindGameObjectWithTag("ShotHandler").GetComponent<ShotHandler>();       
    }

    void Update()
    {
        timer.text = ((int)timeRemaining).ToString("D2");
        if (powerupActive) timeRemaining -= Time.deltaTime;

        if (!GameManager.gameActive) timeRemaining = 0;
        if (timeRemaining <= 0)
        {
            powerupActive = false;
            sh.SwitchActiveShot(ShotHandler.ShootType.Single);
            DisableFansAndSpikes();
            DecolorAll();

        }
        
    }

    void DecolorAll()
    {
        spreadShotRect.GetComponent<ScrollableContent>().DeselectColor();
        laserShotRect.GetComponent<ScrollableContent>().DeselectColor();
        spikesRect.GetComponent<ScrollableContent>().DeselectColor();
        fanRect.GetComponent<ScrollableContent>().DeselectColor();
    }

    void DisableFansAndSpikes()
    {
        Destroy(GameObject.FindGameObjectWithTag("FanAndSpikes"));
    }

    public void Select(RectTransform rt)
    {
        if (powerupActive) return;
        if (!GameManager.gameActive) return;
        if (rt.Equals(spreadShotRect)) ActivateSpreadShot();
        if (rt.Equals(laserShotRect)) ActivateLaserShot();
        if (rt.Equals(spikesRect)) ActivateSpikes();
        if (rt.Equals(fanRect)) ActivateFan();
    }

    void ActivateSpikes()
    {
        if (PlayerManager.coins < spikesCost) return;
        powerupActive = true;
        spikesRect.GetComponent<ScrollableContent>().SelectColor();
        PlayerManager.coins -= spikesCost;
        PlayerManager.SaveCoins();
        sh.SwitchActiveShot(ShotHandler.ShootType.Spikes);
        timeRemaining = 15;
    }

    void ActivateFan()
    {
        if (PlayerManager.coins < fanCost) return;
        powerupActive = true;
        fanRect.GetComponent<ScrollableContent>().SelectColor();
        PlayerManager.coins -= fanCost;
        PlayerManager.SaveCoins();
        sh.SwitchActiveShot(ShotHandler.ShootType.Fan);
        timeRemaining = 15;
    }

    void ActivateSpreadShot()
    {
        if (PlayerManager.coins < spreadShotCost) return;
        powerupActive = true;
        spreadShotRect.GetComponent<ScrollableContent>().SelectColor();
        PlayerManager.coins -= spreadShotCost;
        PlayerManager.SaveCoins();
        sh.SwitchActiveShot(ShotHandler.ShootType.Spread);
        timeRemaining = 15;
    }

    void ActivateLaserShot()
    {
        if (PlayerManager.coins < laserShotCost) return;
        powerupActive = true;
        laserShotRect.GetComponent<ScrollableContent>().SelectColor();
        PlayerManager.coins -= laserShotCost;
        PlayerManager.SaveCoins();
        sh.SwitchActiveShot(ShotHandler.ShootType.Laser);
        timeRemaining = 15;
    }

}
