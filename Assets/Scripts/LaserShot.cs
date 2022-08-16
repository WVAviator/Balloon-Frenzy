using UnityEngine;
using System.Collections;

public class LaserShot : MonoBehaviour {

    public float lifetime = 0.1f;
    public float speed = 0.5f;

    BasePanel bp;

    bool externalDisable = false;

    void Start()
    {
        bp = GameObject.FindGameObjectWithTag("BasePanel").GetComponent<BasePanel>();
    }

    void Update()
    {
        externalDisable = !bp.powerupActive;

        if (!Input.GetMouseButton(0) && Input.touchCount < 1 || externalDisable)
        {
            Destroy(gameObject, lifetime);
            return;
        }

        if (Input.GetMouseButton(0)) UpdatePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (!(Input.touchCount > 0)) return;
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved) UpdatePosition(Camera.main.ScreenToWorldPoint(touch.position));

        
        
    }

    void UpdatePosition(Vector2 pos)
    {
        transform.position = Vector2.MoveTowards(transform.position, pos, speed);
    }
}
