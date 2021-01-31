using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector2 _direction;
    private Animator _animator;
    private PlayerCollisions collisions;

    private void Start()
    {
        _animator = GetComponent <Animator>();
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
        collisions.Move(_direction * speed * Time.deltaTime);
        SetAnimation(_direction);
    }

    private void TakeInput()
    {
        _direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _direction += Vector2.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _direction += Vector2.left;
        }
    }

    private void SetAnimation(Vector2 dir)
    {
        _animator.SetFloat("xDir", _direction.x);
        _animator.SetFloat("yDir", _direction.y);
    }
}
