using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    float health;
    float xScale;
    RectTransform rt;

    void Start()
    {
        health = GameManager.health;
        rt = GetComponent<RectTransform>();
        xScale = rt.sizeDelta.x;
    }

    void Update()
    {
        if (health == GameManager.health) return;
        health = GameManager.health;
        rt.sizeDelta = new Vector2(xScale * (health / 100), rt.sizeDelta.y);
    }
}
