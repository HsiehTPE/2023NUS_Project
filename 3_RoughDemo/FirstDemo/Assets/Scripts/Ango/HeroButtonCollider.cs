using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroButtonCollider : MonoBehaviour
{
    Main_Charactor HeroScript;
    // Start is called before the first frame update
    private void Awake()
    {
        HeroScript = GetComponentInParent<Main_Charactor>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Ground"||collision.tag == "box"||collision.tag == "Barrel"){
            HeroScript.canJump = true;
            HeroScript.myAnime.SetBool("Jump",false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
