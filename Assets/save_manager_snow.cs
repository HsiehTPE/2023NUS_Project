using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save_manager_snow : MonoBehaviour
{
    public GameObject save1,save2;
    public GameObject ango;
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        y=ango.transform.position.y;
        if(y<=20f){
            save1.SetActive(true);
            save2.SetActive(false);
        }
        else{
            save2.SetActive(true);
            save1.SetActive(false);
        }
    }
}
