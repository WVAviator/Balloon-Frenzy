using UnityEngine;
using System.Collections;

public class ShotHandler : MonoBehaviour {

    RectTransform shotZone;
    MainCanvas mc;

    public KeyCode debugKey;

    public GameObject singleShotPrefab;
    public GameObject spreadShotPrefab;
    public GameObject laserShotPrefab;
    public GameObject nukeShotPrefab;
    public GameObject spikesPrefab;
    public GameObject fanPrefab;

    ShootType activeShot;

    public enum ShootType
    {
        Single,
        Spread,
        Laser,
        Nuke,
        Spikes,
        Fan
    }

    void Start()
    {
        shotZone = GameObject.FindGameObjectWithTag("ShotZone").GetComponent<RectTransform>();
        mc = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MainCanvas>();
        activeShot = ShootType.Fan;
    }

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (IsInShotZone(touch.position) && touch.phase == TouchPhase.Began) SpawnShot(Camera.main.ScreenToWorldPoint(touch.position));
        }
        if (Input.GetKeyDown(debugKey)) PlayerManager.AddCoins(10);
        if (Input.GetMouseButtonDown(0) && IsInShotZone(Input.mousePosition)) SpawnShot(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    bool IsInShotZone(Vector2 screenPoint)
    {
        if (!mc.AllWindowsHidden()) return false;
        if (RectTransformUtility.RectangleContainsScreenPoint(shotZone, screenPoint)) return true;
        return false;
    }

    public void SwitchActiveShot(ShootType st)
    {
        activeShot = st;
    }

    void SpawnShot(Vector2 position)
    {

        if (activeShot == ShootType.Single) Inst(singleShotPrefab, position);
        if (activeShot == ShootType.Spread) Inst(spreadShotPrefab, position);
        if (activeShot == ShootType.Laser) Inst(laserShotPrefab, position);
        if (activeShot == ShootType.Nuke) Inst(nukeShotPrefab, position);
        if (activeShot == ShootType.Spikes)
        {
            Inst(spikesPrefab, position);
            activeShot = ShootType.Single;
        }
        if (activeShot == ShootType.Fan)
        {
            Inst(fanPrefab, position);
            activeShot = ShootType.Single;
        }

    }

    void Inst(GameObject prefab, Vector2 position)
    {
        GameObject shot = (GameObject)Instantiate(prefab, position, Quaternion.identity);
    }

}
