using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save1 : MonoBehaviour
{
    private bool isTriggered=false;
    private int num=0;

    private AudioSource myAudio;
    public GameObject f1,f2,f3,f4,f5,f6;
    private GameObject r1,r2,r3,r4,r5,r6;

    public GameObject g1,g2,g3,g4,g5,g6,g7;
    private float delta=0.5f;

    private GameObject t1,t2,t3,t4,t5,t6,t7;
    
    public GameObject ango;
    // Start is called before the first frame update
    public Vector3 pos;

    
    void Start()
    {
        myAudio = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        num++;
        if(num==1){
        myAudio.PlayOneShot(myAudio.clip);
        Color c = GetComponent<Renderer>().material.color;
        c.a = c.a * delta;
        GetComponent<Renderer>().material.color = c;
        }
        isTriggered=true;
        pos=ango.transform.position;

        init1();
        //init2();
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
        if(Input.GetKeyDown(KeyCode.R))
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
                Destroy(g7);
                t7.SetActive(true);
                
                g1=t1;g2=t2;g3=t3;g4=t4;g5=t5;g6=t6;g7=t7;

                ango.transform.position=pos;
                init1();
            }
            /*if(Input.GetKey(KeyCode.T))
            {
                
                Destroy(f1);
                r1.SetActive(true);
                Destroy(f2);
                r2.SetActive(true);
                Destroy(f3);
                r3.SetActive(true);
                Destroy(f4);
                r4.SetActive(true);
                Destroy(f5);
                r5.SetActive(true);
                Destroy(f6);
                r6.SetActive(true);
                
                f1=r1;f2=r2;f3=r3;f4=r4;f5=r5;f6=r6;

                ango.transform.position=pos+new Vector3(60f,34f,0f);
                init2();
            }*/
                
    }

    void init1(){
        t1 = GameObject.Instantiate(g1) as GameObject;
        t2 = GameObject.Instantiate(g2) as GameObject;
        t3 = GameObject.Instantiate(g3) as GameObject;
        t4 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/plat1_1")) as GameObject;
        t5 = GameObject.Instantiate(g5) as GameObject;
        t6 = GameObject.Instantiate(g6) as GameObject;
        t7 = GameObject.Instantiate(g7) as GameObject;

        t1.transform.position=g1.transform.position;
        t2.transform.position=g2.transform.position;
        t3.transform.position=g3.transform.position;
        t4.transform.position=g4.transform.position;
        t5.transform.position=g5.transform.position;
        t6.transform.position=g6.transform.position;
        t7.transform.position=g7.transform.position;

        t4.GetComponent<platform_up2>().butt=t3.GetComponent<button>();
        t4.GetComponent<platform_up2>().X_min=-1f;
        t4.GetComponent<platform_up2>().X_max=3.5f;

        t1.SetActive(false);
        t2.SetActive(false);
        t3.SetActive(false);
        t4.SetActive(false);
        t5.SetActive(false);
        t6.SetActive(false);
        t7.SetActive(false);
    }

    /*void init2(){
        r1 = GameObject.Instantiate(f1) as GameObject;
        r2 = GameObject.Instantiate(f2) as GameObject;
        r3 = GameObject.Instantiate(f3) as GameObject;
        r4 = GameObject.Instantiate(f4) as GameObject;
        r5 = GameObject.Instantiate(f5) as GameObject;
        r6 = GameObject.Instantiate(f6) as GameObject;

        
        r1.transform.position=f1.transform.position;
        r2.transform.position=f2.transform.position;
        r3.transform.position=f3.transform.position;
        r4.transform.position=f4.transform.position;
        r5.transform.position=f5.transform.position;
        r6.transform.position=f6.transform.position;


        r4.GetComponent<platform_up>().butt=r6.GetComponent<button>();
        r4.GetComponent<platform_up>().X_min=40f;
        r4.GetComponent<platform_up>().X_max=46f;

        r1.SetActive(false);
        r2.SetActive(false);
        r3.SetActive(false);
        r4.SetActive(false);
        r5.SetActive(false);
        r6.SetActive(false);

        
    }*/
}
