using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flooor : MonoBehaviour
{
    public GameObject[] floorTiles = new GameObject[4];
    
    // Start is called before the first frame update
    void Start()
    {
        // -9.5 -20.5
        for (int x = -9; x < 150; x++)
        {
            for (int y = -20; y > -220; y--)
            {
                int rand = Random.Range(0, 3);

                Instantiate(floorTiles[rand], new Vector2(x - 0.5f, y - 0.5f), Quaternion.identity);
            }
        }
        
    }
}
