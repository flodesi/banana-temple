using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Vector2 direction
    {
        get;
        private set;
    }
    public Vector2 last_direction
    {
        get;
        private set;
    }
    private PlayerCollisions collisions;

    private void Start()
    {
        collisions = GetComponent<PlayerCollisions>();
    }

    void Update()
    {
        TakeInput();
        Move();
    }

    private void Move()
    {
        collisions.PreUpdate();
        collisions.Move(direction * speed * Time.deltaTime);
    }

    private void TakeInput()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
        // Doesn't make sense that running in a diagonal is faster than running in a cardinal direction
        direction.Normalize();
        last_direction = direction == Vector2.zero ? last_direction : direction;
    }

   

}
