using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    public GameObject ango;
    private float x,y,z;
    private AudioSource myAudio;

    // Start is called before the first frame update
    void Start()
    {
        x=ango.transform.position.x;
        y=ango.transform.position.y;
        z=ango.transform.position.z;
        myAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name=="ango"){
            myAudio.PlayOneShot(myAudio.clip);
            ango.transform.position=new Vector3(x,y,z);
        }
    }
}
