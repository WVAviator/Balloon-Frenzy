using UnityEngine;
using System.Collections;

public class PoppedBalloon : MonoBehaviour {

    public float maxX = 3;
    public float maxY = 3;

    void Start()
    {
        Propel(GetPieces());
        Destroy(gameObject, 4);
    }

    public void SetColor(Color color)
    {
        foreach(Rigidbody2D rb in GetPieces())
        {
            rb.GetComponent<SpriteRenderer>().color = color;
        }
    }

    Rigidbody2D[] GetPieces()
    {
        Rigidbody2D[] rbs = GetComponentsInChildren<Rigidbody2D>();
        Rigidbody2D[] outRbs = new Rigidbody2D[rbs.Length - 1];

        int j = 0;
        for(int i = 0; i < rbs.Length; i++)
        {
            if (rbs[i].gameObject.name.Equals("String")) continue;
            outRbs[j] = rbs[i];
            j++;
        }

        return outRbs;
    }

    void Propel(Rigidbody2D[] rbs)
    {
        foreach (Rigidbody2D rb in rbs)
        {
            rb.velocity = GetRandomVector();
        }
    }

    Vector2 GetRandomVector()
    {
        return new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));
    }
}
