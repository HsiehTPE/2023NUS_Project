using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroBehavior : MonoBehaviour {
    
    private EggSpawnSystem mEggSystem = null;
    private const float kHeroRotateSpeed = 90f/2f; // 90-degrees in 2 seconds
    private const float kHeroSpeed = 20f;  // 20-units in a second
    private float mHeroSpeed = kHeroSpeed;
    
    public CoolDownBar mCoolDown;
    private bool mMouseDrive = true;
    //  Hero state
    private int mHeroTouchedEnemy = 0;
    private void TouchedEnemy() { mHeroTouchedEnemy++; }
    public string GetHeroState() { return "HERO: Drive(" + (mMouseDrive?"Mouse":"Key") + 
                                          ") TouchedEnemy(" + mHeroTouchedEnemy + ")   " 
                                            + mEggSystem.EggSystemStatus(); }

    private void Awake()
    {
        // Actually since Hero spwans eggs, this can be done in the Start() function, but, 
        // just to show this can also be done here.
        mEggSystem = new EggSpawnSystem();
    }

    void Start ()
    { 
    }
	
	// Update is called once per frame
	void Update () {
        UpdateMotion();
        ProcessEggSpwan();
    }

    private int EggsOnScreen() { return mEggSystem.GetEggCount();  }

    private void UpdateMotion()
    {
        if (Input.GetKeyDown(KeyCode.M))
            mMouseDrive = !mMouseDrive;
            
        // Only support rotation
        transform.Rotate(Vector3.forward, -1f * Input.GetAxis("Horizontal") *
                                    (kHeroRotateSpeed * Time.smoothDeltaTime));
        if (mMouseDrive)
        {
            Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            p.z = 0f;
            transform.position = p;
        } else
        {
            mHeroSpeed += Input.GetAxis("Vertical");
            transform.position += transform.up * (mHeroSpeed * Time.smoothDeltaTime);
        }
    }

      private void ProcessEggSpwan()
    {
        if (mEggSystem.CanSpawn())
        {
            if (Input.GetKey("space"))
            {
                // mCoolDown.SetActive(!mCoolDown.activeSelf);
                if (mCoolDown.ReadyForNext())
                {
                    mEggSystem.SpawnAnEgg(transform.position, transform.up);
                    mCoolDown.TriggerCoolDown();
                }
                // mCoolDown.SetActive(!mCoolDown.activeSelf);
            }
            mCoolDown.SetCoolDownLength(0.2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hero touched");
        if (collision.gameObject.name == "Enemy"
        ||collision.gameObject.name == "Enemy (1)"
        ||collision.gameObject.name == "Enemy (2)"
        ||collision.gameObject.name == "Enemy (3)"
        ||collision.gameObject.name == "Enemy (4)"
        ||collision.gameObject.name == "Enemy (5)"
        ||collision.gameObject.name == "Enemy (6)"
        ||collision.gameObject.name == "Enemy (7)"
        ||collision.gameObject.name == "Enemy (8)"
        ||collision.gameObject.name == "Enemy (9)")
            TouchedEnemy();
    }
}