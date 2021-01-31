using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    private Vector2 position;

    public GameObject cam0;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    public GameObject cam5;
    public GameObject cam6;
    public GameObject cam7;
    public GameObject cam8;
    public GameObject cam9;
    public GameObject cam10;
    public GameObject cam11;
    public GameObject cam12;
    public GameObject cam13;
    public GameObject cam14;
    public GameObject cam15;
    
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        print(position);
        if (position.x < 11 && position.y > -41)
        {
            cam0.SetActive(true);
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
            cam14.SetActive(false);
            cam15.SetActive(false);
        } 
        else if (position.x > 11 && position.x < 32 && position.y > -41)
        {
            cam0.SetActive(false);
            cam1.SetActive(!false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
            cam14.SetActive(false);
            cam15.SetActive(false);
        }
        else if (position.x > 32 && position.x < 53 && position.y > -41)
        {
            cam0.SetActive(false);
            cam1.SetActive(false);
            cam2.SetActive(!false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
            cam14.SetActive(false);
            cam15.SetActive(false);
        }
        else if (position.x > 53 && position.y > -41)
        {
            cam0.SetActive(false);
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(!false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
            cam14.SetActive(false);
            cam15.SetActive(false);
        }
        else if (position.x < 11 && position.y < -41 && position.y > -62)
        {
            cam0.SetActive(false);
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(!false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
            cam14.SetActive(false);
            cam15.SetActive(false);
        }
        else if (position.x > 11 && position.x < 32 && position.y < -41 && position.y > -62)
        {
            cam0.SetActive(false);
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(!false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
            cam14.SetActive(false);
            cam15.SetActive(false);
        }
        else if (position.x > 32 && position.x < 53 && position.y < -41 && position.y > -62)
        {
            cam0.SetActive(false);
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(!false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
            cam14.SetActive(false);
            cam15.SetActive(false);
        }
        else if (position.x > 53 && position.y < -41 && position.y > -62)
        {
            cam0.SetActive(false);
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(!false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
            cam14.SetActive(false);
            cam15.SetActive(false);
        }
        else if (position.x < 11 && position.y < -62 && position.y > -83)
        {
            cam0.SetActive(false);
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(!false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
            cam14.SetActive(false);
            cam15.SetActive(false);
        }
        else if (position.x > 11 && position.x < 32 && position.y < -62 && position.y > -83)
        {
            cam0.SetActive(false);
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(!false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
            cam14.SetActive(false);
            cam15.SetActive(false);
        }
        else if (position.x > 32 && position.x < 53 && position.y < -62 && position.y > -83)
        {
            cam0.SetActive(false);
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(!false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
            cam14.SetActive(false);
            cam15.SetActive(false);
        }
        else if (position.x > 53 && position.y < -62 && position.y > -83)
        {
            cam0.SetActive(false);
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(!false);
            cam12.SetActive(false);
            cam13.SetActive(false);
            cam14.SetActive(false);
            cam15.SetActive(false);
        }
        else if (position.x < 11 && position.y < -83)
        {
            cam0.SetActive(false);
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(!false);
            cam13.SetActive(false);
            cam14.SetActive(false);
            cam15.SetActive(false);
        }
        else if (position.x > 11 && position.x < 32 && position.y < -83)
        {
            cam0.SetActive(false);
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(!false);
            cam14.SetActive(false);
            cam15.SetActive(false);
        }
        else if (position.x > 32 && position.x < 53 && position.y < -83)
        {
            cam0.SetActive(false);
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
            cam14.SetActive(!false);
            cam15.SetActive(false);
        }
        else if (position.x > 53 && position.y < -83)
        {
            cam0.SetActive(false);
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
            cam14.SetActive(false);
            cam15.SetActive(!false);
        }
    }
}
