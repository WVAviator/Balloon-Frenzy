using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour {

    Color origColor;
    public Color pressedColor;

    Image image;
    Sound snd;
    RectTransform rt;

    void Start()
    {
        image = GetComponent<Image>();
        origColor = image.color;
        snd = GameObject.FindGameObjectWithTag("Sounds").GetComponent<Sound>();
        rt = GetComponent<RectTransform>();
    }

    public void OnPress()
    {
        image.color = pressedColor;
        snd.PlaySound(snd.menuClick, 0);
    }

    public void OnRelease()
    {
        image.color = origColor;
        snd.PlaySound(snd.menuClick, 0);
    }

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (!RectTransformUtility.RectangleContainsScreenPoint(rt, touch.position)) return;
            if (touch.phase == TouchPhase.Began) OnPress();           
            if (touch.phase == TouchPhase.Ended) OnRelease();
        }
        if (Input.touchCount < 1 && image.color == pressedColor) image.color = origColor;
    }
}
