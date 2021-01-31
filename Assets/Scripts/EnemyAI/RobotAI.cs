using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProjectileCollisions))]
public class RobotAI : MonoBehaviour
{
    // idgaf lol
    private string state;
    public float cooldown;
    public GameObject player;
    private Quaternion fromRotation;
    private Quaternion toRotation;
    private Vector2 direction;
    private ProjectileCollisions collisions;
    // Start is called before the first frame update
    void Start()
    {
        collisions = GetComponent<ProjectileCollisions>();
        StartCoroutine(Cooldown());
    }

    void Update()
    {
        if (state == "charging rotation")
        {
            direction = (player.transform.position - transform.position);
            float atan2 = Mathf.Atan2(direction.y, direction.x) + Mathf.PI / 2;
            transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg);
            
        }
        else if (state == "charging at player")
        {

        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        int attackChoice = Random.Range(0, 2);
        attackChoice = 0;
        switch (attackChoice)
        {
            case 0:
                StartCoroutine(InitCharge());
                break;
            case 1:
                break;
            case 2:
                break;
            default:
                break;
        }
    }

    IEnumerator InitCharge()
    {
        // angry animation, wait to complete
        yield return new WaitForSeconds(1);
        state = "charging rotation";
        StartCoroutine(Targeting());
    }

    IEnumerator Targeting()
    {
        yield return new WaitForSeconds(1);
        state = "charging at player";
    }
}
