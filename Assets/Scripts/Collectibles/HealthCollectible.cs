using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            collision.gameObject.GetComponent<Health>()?.Heal(1);
            Destroy(gameObject);
        }
        
    }
}
