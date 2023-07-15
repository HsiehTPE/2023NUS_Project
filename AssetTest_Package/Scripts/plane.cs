using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane : MonoBehaviour
{
    private bool flagj=true;
    private GameObject mEnemyTemplate = null;

    private int mNumHit = 0;
    private const int kHitsToDestroy = 4;
    private const float kEnemyEnergyLost = 0.8f;

    private const float kTurnRate = 0.03f;
    private const float kMySpeed = 20f;
    private const float kVeryClose = 30f;

    private const int kMaxEnemy = 10;

    private int mTotalEnemy = 10;

    private CameraSupport mMainCamera;

    public GameObject target;
    public GameObject targeta;
    public GameObject targetb;
    public GameObject targetc;
    public GameObject targetd;
    public GameObject targete;
    public GameObject targetf;

    public enum state
    {
        aa,
        bb,
        cc,
        dd,
        ee,
        ff
    };

    public state mState ;

    private Vector2 mSpawnRegionMin, mSpawnRegionMax;

    public static int mEnemyDestroyed = 0;
    // Start is called before the first frame update
    void Start()
    {
        iniState();
        Debug.Assert(targeta!=null);
        Debug.Assert(targetb!=null);
        Debug.Assert(targetc!=null);
        Debug.Assert(targetd!=null);
        Debug.Assert(targete!=null);
        Debug.Assert(targetf!=null);

        mMainCamera = Camera.main.GetComponent<CameraSupport>();
        Debug.Assert(mMainCamera != null);

        Bounds b = mMainCamera.GetWorldBound();

        mSpawnRegionMin = b.min * 0.9f;
        mSpawnRegionMax = b.max * 0.9f;
        mEnemyTemplate = Resources.Load<GameObject>("Prefabs/Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J)){
            flagj=!flagj;
        }
        PointAtPosition(target.transform.localPosition, kTurnRate * Time.smoothDeltaTime);
        transform.localPosition += kMySpeed * Time.smoothDeltaTime * transform.up;
        CheckTargetPosition();
    }

    private void PointAtPosition(Vector3 p, float r)//转向目标
    {
        Vector3 v = p - transform.localPosition;
        transform.up = Vector3.LerpUnclamped(transform.up, v, r);
    }

    private void CheckTargetPosition()//检查距离，太近就更新
    {
        // Access the GameManager
        float dist = Vector3.Distance(target.transform.localPosition, transform.localPosition);
        if (dist < kVeryClose)
        {
            if(flagj){
                switch (mState)
                {
                    case state.aa:
                        mState=state.bb;
                        target=targetb;
                        break;
                    case state.bb:
                        mState=state.cc;
                        target=targetc;
                        break;
                    case state.cc:
                        mState=state.dd;
                        target=targetd;
                        break;
                    case state.dd:
                        mState=state.ee;
                        target=targete;
                        break;
                    case state.ee:
                        mState=state.ff;
                        target=targetf;
                        break;
                    case state.ff:
                        mState=state.aa;
                        target=targeta;
                        break;
                }
            }
            else{
                iniState();
            }
        }
    }

    private void iniState(){
        float tmp=Random.Range(1f,6.9f);
        int tmpp=(int)tmp;
        switch(tmpp){
            case 1:mState=state.aa;
                target=targeta;
                break;
            case 2:mState=state.bb;
                target=targetb;
                break;
            case 3:mState=state.cc;
                target=targetc;
                break;
            case 4:mState=state.dd;
                target=targetd;
                break;
            case 5:mState=state.ee;
                target=targete;
                break;
            case 6:mState=state.ff;
                target=targetf;
                break;
        }
    }

    #region Trigger into chase or die
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Emeny OnTriggerEnter");
        TriggerCheck(collision.gameObject);
    }

    private void TriggerCheck(GameObject g)
    {
        if (g.name == "Hero")
        {
            ThisEnemyIsHit();

        } else if (g.name == "Egg(Clone)")
        {
            mNumHit++;
            if (mNumHit < kHitsToDestroy)
            {
                Color c = GetComponent<Renderer>().material.color;
                c.a = c.a * kEnemyEnergyLost;
                GetComponent<Renderer>().material.color = c;
            } else
            {
                mNumHit--;
                ThisEnemyIsHit();
            }
        }
    }

    private void ThisEnemyIsHit()
    {
        Color c = GetComponent<Renderer>().material.color;

        for(int i=1;i<=mNumHit;i++){
            c.a=c.a/kEnemyEnergyLost;
        }
        GetComponent<Renderer>().material.color = c;
        float x = Random.Range(mSpawnRegionMin.x, mSpawnRegionMax.x);
        float y = Random.Range(mSpawnRegionMin.y, mSpawnRegionMax.y);
        gameObject.transform.position=new Vector3(x,y,0f);
        iniState();
        mEnemyDestroyed++;
        mNumHit=0;
        /*mEnemyDestroyed++;
        mTotalEnemy--;
        GameObject p = GameObject.Instantiate(mEnemyTemplate) as GameObject;
        Destroy(gameObject);
        */
    }

    public void OneEnemyDestroyed() { mEnemyDestroyed++;  ReplaceOneEnemy(); }
    public void ReplaceOneEnemy() { mTotalEnemy--; GenerateEnemy(); }
    public string GetEnemyState() { return "ENEMY: Count(" + mTotalEnemy + ") Destroyed(" + mEnemyDestroyed + ")" + " WayPoints: "+ (flagj?"Sequence":"Random"); }

    private void GenerateEnemy()
    {
        GameObject p = GameObject.Instantiate(mEnemyTemplate) as GameObject;
        float x = Random.Range(mSpawnRegionMin.x, mSpawnRegionMax.x);
        float y = Random.Range(mSpawnRegionMin.y, mSpawnRegionMax.y);
        p.transform.position = new Vector3(x, y, 0f);
        mTotalEnemy++;
    }
    #endregion
}
