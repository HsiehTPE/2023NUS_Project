using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    private int life=2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Weapon"){
            life--;
            if(life < 1){
                Destroy(gameObject);
            }
        }
    }

    public void FallDown() {Destroy(gameObject);}
}
