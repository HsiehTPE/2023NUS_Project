using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Light_Control : MonoBehaviour
{
    Vector3 pos;
    int num=0;
    public GameObject l;
    public GameObject t;
    public Main_Charactor player;
    Animator Anime;
    public bool touched = false;

    void Update()
    {
        if(touched&&Input.GetKeyDown(KeyCode.J)&&num==0)
        {
            l.SetActive(true);
            t.SetActive(false);
            Anime.SetTrigger("Burn");
            transform.position=new Vector3(pos.x,pos.y+0.55f,pos.z);
            num++;
        }
    }

    void Awake()
    {
        Anime = GetComponent<Animator>();
        pos=transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "ango"&&player.hasTorch)
        {
            touched = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "ango"&&player.hasTorch)
        {
            touched = false;
        }
    }
}
