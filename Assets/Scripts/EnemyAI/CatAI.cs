using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAI : MonoBehaviour
{

    public GameObject bullet;
    public GameObject player;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public float cooldown;


    private void Start()
    {
        ObjectPooler.instance.CreatePool(bullet, 50);
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(Shoot());
        animator.Play("CatIdle");
    }



    IEnumerator Shoot()
    {
        animator.Play("CatIdle");
        yield return new WaitForSeconds(cooldown);
        if (player != null)
        {
            animator.Play("CatShoot");
            for (int i = 0; i < 3; i++)
            {
                
                GameObject bullh = ObjectPooler.instance.ReuseObject(bullet, transform.position, Quaternion.identity);
                Vector2 directionh = (player.transform.position - transform.position).normalized;
                spriteRenderer.flipX = directionh.normalized.x < 0;
                bullh.GetComponent<Bullet>().SetDirection(directionh);
                yield return new WaitForSeconds(0.2f);

            }
            // if you manage to read this, just don't even ask please...
            GameObject bull = ObjectPooler.instance.ReuseObject(bullet, transform.position, Quaternion.identity);
            Vector2 direction = (player.transform.position - transform.position).normalized;
            spriteRenderer.flipX = direction.normalized.x < 0;
            bull.GetComponent<Bullet>().SetDirection(direction);

            StartCoroutine(Shoot());
        }
        
    }


}
