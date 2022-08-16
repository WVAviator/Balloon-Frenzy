using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    float interval = 1;
    float time = 0;
    public float spawnFactor = 0.5f;
    public bool gameIsActive = false;

    public GameObject balloonPrefab;
    public float spawnRange;

    void Update()
    {
        time += Time.deltaTime;
        interval = spawnFactor / time;

        if (!gameIsActive)
        {
            time = 0;
            interval = 1;
        }
    }

    public void Activate()
    {
        gameIsActive = true;
        time = 0;
        interval = 1;
        StartCoroutine("SpawnSequence");
    }

    IEnumerator SpawnSequence()
    {
        while(gameIsActive)
        {
            SpawnBalloon();
            float variance = Random.Range(0.9f, 1.1f);
            yield return new WaitForSeconds((interval >= 2f) ? 2f : (interval * variance));
        }
    }

    void SpawnBalloon()
    {
        Vector2 pos = new Vector2(Random.Range(-spawnRange, spawnRange), transform.position.y);
        GameObject balloon = (GameObject)Instantiate((GameObject)balloonPrefab, pos, transform.rotation);
    }
}
