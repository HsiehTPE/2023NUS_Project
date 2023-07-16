using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject[] gos;
    Animator Anime;

    void Awake(){
        Anime = GetComponent<Animator>();
    }

    public void FallDown(){
        Vector3 pos = transform.position;
        Instantiate(gos[Random.Range(0,gos.Length)],pos,Quaternion.identity);
        Anime.SetBool("Break",true);
        Destroy(gameObject,0.6f);
    }
}
