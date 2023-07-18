using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_key : MonoBehaviour
{
    public GameObject ango_obj=null;
    public Main_Charactor ango=null;
    private float posx,posy,posz;
    private float y_max;
    private float tmpy;
    private float delta=5f;
    private float hello=3f;
    private bool willup;
    private Vector3 up=new Vector3(0f, 1f, 0f);
    private AudioSource myAudio;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(ango!=null);
        Debug.Assert(ango_obj!=null);
        posx=transform.localPosition.x;
        posy=transform.localPosition.y;
        posz=transform.localPosition.z;
        tmpy=posy+delta;
        y_max = 2.72f;
        myAudio = GetComponent<AudioSource>();
        willup = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ango.gm.numKey);
        transform.up=up;
        
        float dist = Vector3.Distance(ango_obj.transform.localPosition, transform.localPosition);
        if(dist<hello){
            check_key();
        }
        if(willup && transform.localPosition.y <= y_max)
        {
            transform.localPosition += new Vector3(0f,0.05f,0f);
        }
    }

    private void check_key(){
        if(ango.gm.numKey>0)
        {
            if(Input.GetKey(KeyCode.E))
            {
                ango.gm.numKey--;
                myAudio.PlayOneShot(myAudio.clip);
                willup = true;
            }
        }
    }
}
