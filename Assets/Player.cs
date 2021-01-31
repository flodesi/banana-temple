using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public float speed;
    private Vector2 _direction;
    private Animator _animator;
    private PlayerCollisions collisions;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        _animator = GetComponent <Animator>();
        collisions = GetComponent<PlayerCollisions>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        TakeInput();
        Move();
    }

    private void Move()
    {
        collisions.PreUpdate();
        collisions.Move(_direction * speed * Time.deltaTime);
        SetAnimation(_direction);
    }

    private void TakeInput()
    {
        _direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _direction += Vector2.right;
        }
        // Doesn't make sense that running in a diagonal is faster than running in a cardinal direction
        _direction.Normalize();
    }

    private void SetAnimation(Vector2 dir)
    {
        if (Mathf.Abs(dir.x) > 0)
        {
            _animator.Play("MonkeyRunRight");
            spriteRenderer.flipX = dir.x == -1;

        } 
        else if (Mathf.Abs(dir.y) > 0)
        {
            if (dir.y > 0)
            {
                _animator.Play("MonkeyRunUp");
            }
            else
            {
                _animator.Play("MonkeyRunDown");
            }
        }
        else
        {
            _animator.Play("MonkeyDownIdle");
        }
    }
}
