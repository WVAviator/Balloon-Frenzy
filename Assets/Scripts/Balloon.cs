using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

    public PoppedBalloon poppedBalloon;
    public Health healthPrefab;
    public Coin coinPrefab;
    public float maxHeight = 8;
    public float randomDir = 3;
    public float speed = 1;

    public float chanceHealth = 0.03f;
    public float chanceCoin = 0.01f;

    float screenEdge;

    public Color[] possibleColors;

    bool hasPopped;

    SpriteRenderer sr;
    Transform llBounds;
    Transform urBounds;
    Rigidbody2D rb;
    Sound sound;

    void Start()
    {
        llBounds = transform.FindChild("LowerLeftBounds");
        urBounds = transform.FindChild("UpperRightBounds");
        sr = transform.FindChild("Balloon").GetComponent<SpriteRenderer>();
        sr.color = GetRandomColor();
        rb = GetComponent<Rigidbody2D>();
        sound = GameObject.FindGameObjectWithTag("Sounds").GetComponent<Sound>();

        screenEdge = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height) - 0.65f;

        rb.velocity = new Vector2(Random.Range(-randomDir, randomDir), rb.velocity.y);

    }

    void Pop()
    {
        if (hasPopped) return;
        hasPopped = true;

        PlayerManager.AddPop();

        sound.PlaySound(sound.popSound, 0.05f);

        PoppedBalloon popped = (PoppedBalloon)Instantiate(poppedBalloon, transform.position, transform.rotation);
        popped.SetColor(sr.color);

        if (chanceHealth > Random.Range(0, 1f)) SpawnHealth();
        if (chanceCoin > Random.Range(0, 1f)) SpawnCoin();

        GameManager.AddScore(1);
        Destroy(gameObject);
    }

    void SpawnHealth()
    {
        Health healthPack = (Health)Instantiate(healthPrefab, transform.position, transform.rotation);
    }

    void SpawnCoin()
    {
        Coin coinCopy = (Coin)Instantiate(coinPrefab, transform.position, transform.rotation);
    }

    void Move()
    {
        rb.velocity = new Vector2(rb.velocity.x, speed);
    }

    void Update()
    {
        Move();

        
        if (IsTooHigh())
        {
            if(GameManager.gameActive) GameManager.DecreaseHealth(7);
            Destroy(gameObject);
        }
        if (!GameManager.gameActive) return;

        /*foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began && IsPointInBounds(Camera.main.ScreenToWorldPoint(touch.position))) Pop();           
        }

        if (Input.GetMouseButtonDown(0) && IsPointInBounds(Camera.main.ScreenToWorldPoint(Input.mousePosition))) Pop();
        */
        if (IsAtEdge()) ReverseDirection();

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag.Equals("Shot")) Pop();
    }

    void OnTriggerStay2D(Collider2D c)
    {
        if (c.gameObject.tag.Equals("SuckZone"))
        {
            Transform fan = c.transform.parent.transform;
            float velocityAdded = fan.GetComponent<Fan>().velocityAdded;
            if (fan.position.x < rb.transform.position.x) rb.velocity += new Vector2(-velocityAdded, 0);
            if (fan.position.x > rb.transform.position.x) rb.velocity += new Vector2(velocityAdded, 0);
        }
    }

    void ReverseDirection()
    {
        rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
    }

    bool IsAtEdge()
    {
        if (transform.position.x <= -screenEdge || transform.position.x >= screenEdge) return true;
        return false;
    }

    bool IsPointInBounds(Vector2 point)
    {
        if (point.x >= llBounds.position.x && point.x <= urBounds.position.x &&
            point.y >= llBounds.position.y && point.y <= urBounds.position.y) return true;
        return false;
    }

    bool IsTooHigh()
    {
        return transform.position.y >= maxHeight;
    }

    Color GetRandomColor()
    {
        int rand = Random.Range(0, possibleColors.Length);
        return possibleColors[rand];
    }
}
