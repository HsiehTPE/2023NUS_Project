using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ice : MonoBehaviour
{
    public GameObject weapon=null;
    private int life=3;
    public Main_Charactor hero_script=null;
    public GameObject hero=null;
    private float delta=3f;
    private float minus=0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(hero!=null);
    }

    // Update is called once per frame
    void Update()
    {
        if(hero_script.equip_torch()){
            float dist = Vector3.Distance(hero.transform.localPosition, transform.localPosition);
            if(dist<delta){
                float s = transform.localScale.x;
                if(s>0){
                s -= minus*Time.smoothDeltaTime;
                delta-=minus*Time.smoothDeltaTime*0.8f;
                }
                transform.localScale = new Vector3(s, s, 1);
                if(s<1f) Destroy(gameObject);
            }
        }
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
}
