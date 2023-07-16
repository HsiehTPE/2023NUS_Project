using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_up : MonoBehaviour
{
    public button butt;
    private bool flag;
    private bool lever_state;
    private float Elevatorspeed;
    private float X_min,X_max;
    void Start()
    {
        flag = true;
        Elevatorspeed = 2f;
        X_min = 0f;
        X_max = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        lever_state = butt.Triggered();
        if(!lever_state)
        {
            if(transform.position.y < X_max){
                go_up();
            }
        }
        else
        {
            if(transform.position.y > X_min)
                go_down();
        }
    }

    private void go_up(){
        transform.position += new Vector3(0f,Elevatorspeed * Time.deltaTime,0f);
    }

    private void go_down(){
        transform.position -= new Vector3(0f,Elevatorspeed * Time.deltaTime,0f);
    }
}
