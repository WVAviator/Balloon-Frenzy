using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollableContent : MonoBehaviour {

    public float dragThreshold = 0.1f;
    int touchTime = 0;
    bool isTouching;

    public Color selectedColor;
    Color origColor;

    RectTransform rt;
    BasePanel bp;
    Image image;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        bp = GameObject.FindGameObjectWithTag("BasePanel").GetComponent<BasePanel>();
        image = GetComponent<Image>();
        origColor = image.color;
    }

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(rt, touch.position))
            {
                if (touch.phase == TouchPhase.Began) StartCoroutine(TouchCount());
                if (touch.phase == TouchPhase.Ended && isTouching)
                {
                    bp.Select(rt);
                    isTouching = false;
                    //touchTime = 0;
                }
                /*if (touch.phase == TouchPhase.Ended && !isTouching)
                {
                    isTouching = false;
                    touchTime = 0;
                }*/
            }
        }

        /*if (Input.GetMouseButtonDown(0) && RectTransformUtility.RectangleContainsScreenPoint(rt, Input.mousePosition)) isTouching = true;
        if (Input.GetMouseButtonUp(0) && touchTime < dragThreshold && isTouching)
        {
            bp.Select(rt);
            SelectColor();
            isTouching = false;
            touchTime = 0;
        }*/

        //if (isTouching) touchTime++;
    }

    IEnumerator TouchCount()
    {
        isTouching = true;
        yield return new WaitForSeconds(dragThreshold);
        isTouching = false;
    }

    public void SelectColor()
    {
        image.color = selectedColor;
    }

    public void DeselectColor()
    {
        image.color = origColor;
    }
}
