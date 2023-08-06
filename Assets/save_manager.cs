using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save_manager : MonoBehaviour
{
    public GameObject save1,save2,save3;
    public GameObject ango;
    private float x;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        x=ango.transform.position.x;
        if(x<=100f){
            save1.SetActive(true);
            save2.SetActive(false);
            save3.SetActive(false);
        }
        else if(x>=177f){
            save3.SetActive(true);
            save2.SetActive(false);
            save1.SetActive(false);
        }
        else{
            save2.SetActive(true);
            save1.SetActive(false);
            save3.SetActive(false);
        }
    }
}
