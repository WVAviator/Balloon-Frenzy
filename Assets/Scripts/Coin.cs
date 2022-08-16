using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    Transform llBounds;
    Transform urBounds;

    void Start()
    {
        llBounds = transform.FindChild("LowerLeftBounds");
        urBounds = transform.FindChild("UpperRightBounds");
    }

    void Update()
    {
        if (!GameManager.gameActive) return;
        foreach (Touch touch in Input.touches)
        {
            if (IsInBounds(Camera.main.ScreenToWorldPoint(touch.position)))
            {
                PlayerManager.AddCoins(1);
                Destroy(gameObject);
            }
        }

        if(Input.GetMouseButtonDown(0) && IsInBounds(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            PlayerManager.AddCoins(1);
            Destroy(gameObject);
        }
    }

    bool IsInBounds(Vector2 point)
    {
        if (point.x >= llBounds.position.x && point.x <= urBounds.position.x &&
            point.y >= llBounds.position.y && point.y <= urBounds.position.y) return true;
        return false;
    }

}
