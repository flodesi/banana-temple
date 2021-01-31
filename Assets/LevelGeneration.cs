using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] startingPositions;
    public GameObject[] rooms; // 0 -> LR 1 -> LRB 2 -> LRT 3 -> LRBT 4 -> L 5 -> R 6 -> T 7 -> B
    public GameObject monkee;
    private bool monkeeSpawn = false;

    private int direction;
    public float moveAmount;

    private float timeBetween;
    public float startTimeBetween = 0.25f;

    public bool stopGen;

    public LayerMask room;

    public float minX;
    public float maxX;
    public float minY;

    private void Start()
    {
        int randStart = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStart].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);
        direction = Random.Range(1, 4);
    }

    private void Update()
    {
        if (timeBetween <= 0 && stopGen == false)
        {
            Move();
            timeBetween = startTimeBetween;
        }
        else
        {
            timeBetween -= Time.deltaTime;
        }
    }

    private void Move()
    {
        Vector2 poss = transform.position;
        print(direction);
        if (direction == 1) // right
        {
            if (transform.position.x < maxX)
            {
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length - 4);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);
            
                direction = Random.Range(1, 4);
                if (direction == 2)
                {
                    direction = 1;
                }
            }
            else
            {
                direction = 3;
            }
            
        } 
        else if (direction == 2) // left
        {
            if (transform.position.x > minX)
            {
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;
            
                int rand = Random.Range(0, rooms.Length - 4);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);
            
                direction = Random.Range(1, 4);
                if (direction == 1)
                {
                    direction = 2;
                }
            }
            else
            {
                direction = 3;
            }
        } 
        else if (direction == 3) // down
        {
            if (transform.position.y > minY)
            {
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);

                if (roomDetection.GetComponent<roomType>().type != 1 && roomDetection.GetComponent<roomType>().type != 3)
                {
                    roomDetection.GetComponent<roomType>().RoomDestruction();
                    int randBottom = Random.Range(1, 4);
                    if (randBottom == 2)
                    {
                        randBottom = 1;
                    }

                    Instantiate(rooms[randBottom], transform.position, Quaternion.identity);
                }
            
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos;
            
                int rand = Random.Range(2, 4);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);


                direction = Random.Range(1, 4);
            }
            else
            {
                stopGen = true;
            }
        }

        if (monkeeSpawn == false)
        {
            monkee.transform.position = poss;
            monkeeSpawn = true;
        }
    }
}
