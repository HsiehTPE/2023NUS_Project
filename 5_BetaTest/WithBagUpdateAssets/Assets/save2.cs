using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save2 : MonoBehaviour
{
    public GameObject save1;
    private bool isTriggered=false;
    private int num=0;

    private AudioSource myAudio;

    public GameObject g1,g2,g3,g4,g5,g6;
    private float delta=0.5f;

    private GameObject t1,t2,t3,t4,t5,t6;
    
    public GameObject ango;
    // Start is called before the first frame update
    public Vector3 pos;

    
    void Start()
    {
        
        myAudio = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(save1);
        num++;
        if(num==1){
        myAudio.PlayOneShot(myAudio.clip);
        Color c = GetComponent<Renderer>().material.color;
        c.a = c.a * delta;
        GetComponent<Renderer>().material.color = c;
        }
        isTriggered=true;
        pos=ango.transform.position;

        init();
    }

    private void OnTriggerExit2D(Collider2D other) {
        num--;
        if(num==0){
            Color c = GetComponent<Renderer>().material.color;
            c.a = c.a / delta;
            GetComponent<Renderer>().material.color = c;
            isTriggered=false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.T))
            {
                Destroy(g1);
                t1.SetActive(true);
                Destroy(g2);
                t2.SetActive(true);
                Destroy(g3);
                t3.SetActive(true);
                Destroy(g4);
                t4.SetActive(true);
                Destroy(g5);
                t5.SetActive(true);
                Destroy(g6);
                t6.SetActive(true);
                
                
                g1=t1;g2=t2;g3=t3;g4=t4;g5=t5;g6=t6;

                ango.transform.position=pos;
                init();
            }
    }

    void init(){
        t1 = GameObject.Instantiate(g1) as GameObject;
        t2 = GameObject.Instantiate(g2) as GameObject;
        t3 = GameObject.Instantiate(g3) as GameObject;
        t4 = GameObject.Instantiate(g4) as GameObject;
        t5 = GameObject.Instantiate(g5) as GameObject;
        t6 = GameObject.Instantiate(g6) as GameObject;

        
        t1.transform.position=g1.transform.position;
        t2.transform.position=g2.transform.position;
        t3.transform.position=g3.transform.position;
        t4.transform.position=g4.transform.position;
        t5.transform.position=g5.transform.position;
        t6.transform.position=g6.transform.position;


        t4.GetComponent<platform_up>().butt=t6.GetComponent<button>();
        t4.GetComponent<platform_up>().X_min=40f;
        t4.GetComponent<platform_up>().X_max=46f;

        t1.SetActive(false);
        t2.SetActive(false);
        t3.SetActive(false);
        t4.SetActive(false);
        t5.SetActive(false);
        t6.SetActive(false);

        
    }
}
