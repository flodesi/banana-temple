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

    private void Start()
    {
        _animator = GetComponent <Animator>();
    }

    void Update()
    {
        TakeInput();
        Move();
    }

    private void Move()
    {
        transform.Translate( speed * Time.deltaTime * _direction);
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
    }

    private void SetAnimation(Vector2 dir)
    {
        _animator.SetFloat("xDir", _direction.x);
        _animator.SetFloat("yDir", _direction.y);
        print(_animator.GetFloat("xDir"));
    }
}
