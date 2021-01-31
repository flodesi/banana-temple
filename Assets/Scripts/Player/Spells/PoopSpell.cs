using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopSpell : Spell
{
    public GameObject poop;
    private bool canCast = true;
    public float castCooldown;


    private void Start()
    {
        ObjectPooler.instance.CreatePool(poop, 10);
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
        if (!canCast)
        {
            return;
        }
        GameObject projectile = ObjectPooler.instance.ReuseObject(poop, transform.position, Quaternion.identity);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos = transform.position;
        Vector2 direction = (mousePos - myPos).normalized;
        projectile.GetComponent<Bullet>().SetDirection(direction);
        StartCoroutine(CastCooldown());
    }

    IEnumerator CastCooldown()
    {
        canCast = false;
        yield return new WaitForSeconds(castCooldown);
        canCast = true;
    }
}
