using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopSpell : MonoBehaviour
{
    public GameObject poop;


    private void Start()
    {
        ObjectPooler.instance.CreatePool(poop, 20);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            GameObject projectile = ObjectPooler.instance.ReuseObject(poop, transform.position, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = transform.position;
            Vector2 direction = (mousePos - myPos).normalized;
            projectile?.GetComponent<Poop>().SetDirection(direction);

        }
        
    }
}
