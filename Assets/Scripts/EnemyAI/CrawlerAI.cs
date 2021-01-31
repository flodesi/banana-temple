using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerAI : MonoBehaviour
{
    public GameObject player;
    public float cooldown;
    private Vector2 direction;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public float speed;
    private ProjectileCollisions collisions;
    void Start()
    {
        StartCoroutine(Crawl());
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collisions = GetComponent<ProjectileCollisions>();
    }

    private void Update()
    {
        collisions.PreUpdate();
        collisions.Move(Time.deltaTime * speed * direction);
    }


    IEnumerator Crawl()
    {
        yield return new WaitForSeconds(cooldown);
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;


        spriteRenderer.flipX = false;
        spriteRenderer.flipY = false;
        if (Mathf.Abs(playerX - transform.position.x) > Mathf.Abs(playerY - transform.position.y))
        {
            direction = Vector2.right * Mathf.Sign(playerX - transform.position.x);
            spriteRenderer.flipX = direction.x > 0;
            animator.Play("CrawlSide");
        }
        else
        {
            direction = Vector2.up * Mathf.Sign(playerY - transform.position.y);
            animator.Play("CrawlUp");
            spriteRenderer.flipY = direction.y < 0;
        }
        StartCoroutine(Crawl());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
        }
    }
}
