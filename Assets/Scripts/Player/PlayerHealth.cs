using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    bool invincible;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InvincibleTimer()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(2);
        invincible = false;
        spriteRenderer.color = Color.white;
    }

    public override void TakeDamage(int damage)
    {
        if (!invincible)
        {
            health -= 1;
            if (health <= 0)
            {
                // Die
                Debug.Log("I fucking died");
            }
            else
            {
                invincible = true;
                StartCoroutine(InvincibleTimer());
            }
        }

    }




}
