using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Poop : PoolObject
{
    private ProjectileCollisions collisions;
    private Vector2 direction;
    public float speed;

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
        GameObject enemy = collisions.collisions.FirstObjectHit();
        if (enemy != null)
        {
            enemy.GetComponent<Enemy>()?.GetHit(20);
            Destroy();
        }
    }
}
