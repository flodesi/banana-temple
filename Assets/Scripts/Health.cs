using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int health;
    public int max_health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Oh fuck I got hit");
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Oh no I fucking died...");
            OnDeath();
        }
    }

    public void Heal(int health)
    {
        this.health += health;
        if (this.health > max_health)
        {
            this.health = max_health;
        }
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }
}
