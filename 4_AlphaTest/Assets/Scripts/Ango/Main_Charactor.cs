using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Charactor : MonoBehaviour
{
    private Vector3 up=new Vector3(0,1f,0);
    public GameManager gm;
    public float mySpeed;
    public Animator myAnime;
    Rigidbody2D myRigi;
    public bool jump,canJump,isSword;
    public int Attack;
    private int jumpForce;
    public GameObject attackCollider;
    private bool hasTorch;
    public AudioClip[] myAudioClip;

    public bool get_torch = false;
    
    AudioSource myAudio;
    // Start is called before the first frame update

    private void Awake(){
        mySpeed = 5f;
        myAnime = GetComponent<Animator>();
        myRigi = GetComponent<Rigidbody2D>();
        jumpForce = 16;
        Attack = 0;
        isSword = false;
        hasTorch = false;
        myAudio = GetComponent<AudioSource>();
    }

    private void TorchCheck(){
        if(get_torch)
        {
            if(Input.GetKeyDown(KeyCode.I) && !hasTorch && !isSword){
                myAnime.SetBool("Torch",true);
                hasTorch = true;
            }

            else if(Input.GetKeyDown(KeyCode.I) && hasTorch ){
                myAnime.SetBool("Torch",false);
                hasTorch = false;
            }
        }
    }

    private void SwordCheck(){
        if(!isSword && Input.GetKeyDown(KeyCode.K)){
            isSword = true;
            myAnime.SetBool("isSword",isSword);
        }
        else if(Input.GetKeyDown(KeyCode.K) && isSword){
            Attack=0;
            isSword = false;
            myAnime.SetBool("isSword",isSword);
        }
    }

    private void AttackSound()
    {
        myAudio.PlayOneShot(myAudioClip[2]);
    }

    private void AttackCheck(){
        if(Input.GetKeyDown(KeyCode.J) && isSword){
            //gameObject.tag="Weapon";
            Attack++;
            if(Attack == 1) myAnime.SetTrigger("Attack1");
            if(Attack == 2) myAnime.SetTrigger("Attack2");
            if(Attack == 3) myAnime.SetTrigger("Attack3");
            //gameObject.tag="Ango";
            //myAnime.SetInteger("Attack",Attack);
        }
        if(Attack == 3) Attack = 0;
    }
    // Update is called once per frame
    private void Update(){
        transform.up=up;

        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            myAudio.PlayOneShot(myAudioClip[1]);
            jump = true;
        }
        AttackCheck();
        TorchCheck();
        SwordCheck();
    }

    private void FixedUpdate()
    {
        float a=Input.GetAxisRaw("Horizontal");
        if(a!=0 && !myAudio.isPlaying && canJump)
        {
            myAudio.PlayOneShot(myAudioClip[0]);
        }
        if(a>0) transform.localScale = new Vector3(1f,1f,1f);
        else if(a<0) transform.localScale = new Vector3(-1f,1f,1f);

        myAnime.SetFloat("Run",Mathf.Abs(a));

        if(jump){
            myRigi.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
            jump=false;
            myAnime.SetBool("Jump",true);
        }

        myRigi.velocity = new Vector2(a*mySpeed,myRigi.velocity.y);
    }

    public void SetAttackColliderOn(){
        attackCollider.SetActive(true);
    }

    public void SetAttackColliderOff(){
        attackCollider.SetActive(false);
    }

    public bool equip_torch() {return hasTorch;}
    public bool equip_sword() {return isSword;}
}
