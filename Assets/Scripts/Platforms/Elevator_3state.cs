using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_3state : MonoBehaviour
{
    public lever_3state a;
    private bool flag;
    public int times;
    public float Elevatorspeed;
    public float y1,y2,y3,x;
    void Start()
    {
        flag = false;
        Elevatorspeed = 2f;
        transform.position = new Vector3(x,y1,0f);
    }

    // Update is called once per frame
    void Update()
    {
        times = a.Getturn();
        if(times == 3)
        {
            flag = !flag;
            a.turntimes = 1;
            times = 1;
        }
        
        if(flag == false)
        {
            if(times == 1 && transform.position.y < y2)
            {
                transform.position += new Vector3(0f,Elevatorspeed * Time.deltaTime,0f);
            }
            if(times == 2 && transform.position.y < y3)
            {
                transform.position += new Vector3(0f,Elevatorspeed * Time.deltaTime,0f);
            }
        }
        if(flag == true)
        {
            if(times == 1 && transform.position.y > y2)
            {
                transform.position -= new Vector3(0f,Elevatorspeed * Time.deltaTime,0f);
            }
            if(times == 2 && transform.position.y > y1)
            {
                transform.position -= new Vector3(0f,Elevatorspeed * Time.deltaTime,0f);
            }
        }    
    }
}
