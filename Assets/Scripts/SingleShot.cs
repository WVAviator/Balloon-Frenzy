using UnityEngine;
using System.Collections;

public class SingleShot : MonoBehaviour {

    public float lifetime = 0.05f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
