using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    private int life=2;
    private AudioSource myAudio;
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Weapon")
        {
            life--;
            if(life < 1){
                AudioSource.PlayClipAtPoint(myAudio.clip,transform.localPosition,1f);
                Destroy(gameObject);
            }
        }
    }

    public void FallDown() {Destroy(gameObject);}
}
