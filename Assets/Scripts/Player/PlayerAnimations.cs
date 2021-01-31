using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimations : MonoBehaviour
{

    PlayerMovement playerMovement;
    Animator animator;
    SpriteRenderer spriteRenderer;
    bool overrideAnim;
    string overriddenAnimation;
    
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        Animate();
    }


    private void Animate()
    {
        Vector2 direction = playerMovement.direction;
        Vector2 last_direction = playerMovement.last_direction;
        spriteRenderer.flipX = last_direction.x == -1;
        if (Mathf.Abs(direction.x) > 0)
        {
            animator.Play("MonkeyRunRight");

        }
        else if (Mathf.Abs(direction.y) > 0)
        {
            if (direction.y > 0)
            {
                animator.Play("MonkeyRunUp");
            }
            else
            {
                animator.Play("MonkeyRunDown");
            }
        }
        else
        {
            if (Mathf.Abs(last_direction.x) > 0)
            {
                animator.Play("MonkeyIdleRight");

            }
            else if (Mathf.Abs(last_direction.y) > 0)
            {
                if (last_direction.y > 0)
                {
                    animator.Play("MonkeyIdleUp");
                }
                else
                {
                    animator.Play("MonkeyIdleDown");
                }
            }

        }
    }
}
