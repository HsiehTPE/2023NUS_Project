using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever_ball : MonoBehaviour
{
    private bool lever_state;
    private bool canturn;
    private AudioSource myAudio;
    Animator myAnim;

    public GameObject ball;
    private float posx,posy,posz;
    
    // Start is called before the first frame update
    void Start()
    {
        posx=ball.transform.position.x;
        posy=ball.transform.position.y;
        posz=ball.transform.position.z;
        myAudio = GetComponent<AudioSource>();
        myAnim = GetComponent<Animator>();
        lever_state = false;
        canturn = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canturn)
        {
            lever_state=!lever_state;
            ball.transform.position=new Vector3(posx,posy,posz);
            myAudio.PlayOneShot(myAudio.clip);
        }      
        if(lever_state)
            myAnim.SetBool("inverturn",true);
        if(!lever_state)
            myAnim.SetBool("inverturn",false);
    }

    private void FixedUpdate()
    {
        myAnim.SetBool("Turn",lever_state);
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.name == "ango")
            canturn = true;
    } 
    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.name == "ango")
            canturn = false;
    }

    public bool Getturn()
    {
        return lever_state;
    }
}
