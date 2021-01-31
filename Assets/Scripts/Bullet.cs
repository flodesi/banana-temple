using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : PoolObject
{
    private ProjectileCollisions collisions;
    private Vector2 direction;
    public float speed;
    public int damage;

    public void Start()
    {
        collisions = GetComponent<ProjectileCollisions>();
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }

    // Update is called once per frame
    void Update()
    {
        collisions.PreUpdate();
        collisions.Move(direction * speed * Time.deltaTime);
        GameObject hit = collisions.collisions.FirstObjectHit();
        if (hit != null)
        {
            hit.GetComponent<Health>()?.TakeDamage(damage);
            Destroy();
        }
    }
}
