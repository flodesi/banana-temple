using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAI : MonoBehaviour
{

    private float time = 0.0f;
    public float interpolationPeriod = 0.5f;
    public GameObject bullet;
    public GameObject player;
    private Animator animator;


    private void Start()
    {
        ObjectPooler.instance.CreatePool(bullet, 50);
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = time - interpolationPeriod;
            
            print("fack");
            Shoot();
            animator.Play("CatShoot");
        }
    }



    void Shoot()
    {
        GameObject bull = ObjectPooler.instance.ReuseObject(bullet, transform.position, Quaternion.identity);
        Vector2 direction = (player.transform.position - transform.position).normalized;
        bull.GetComponent<Bullet>().SetDirection(direction);
    }
}
