using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopSpell : Spell
{
    public GameObject poop;


    private void Start()
    {
        ObjectPooler.instance.CreatePool(poop, 20);
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cast();
        }
    }

    public override void Cast()
    {
        GameObject projectile = ObjectPooler.instance.ReuseObject(poop, transform.position, Quaternion.identity);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos = transform.position;
        Vector2 direction = (mousePos - myPos).normalized;
        projectile.GetComponent<Bullet>().SetDirection(direction);
    }
}
