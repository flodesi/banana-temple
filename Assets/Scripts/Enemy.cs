using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health
    {
        get;
        private set;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetHit(int damage)
    {
        health -= damage;
        Debug.Log("Ouch");
        if (health < 0)
        {
            Debug.Log("Oh no I died...");
            Destroy(gameObject);
        }
    }
}
