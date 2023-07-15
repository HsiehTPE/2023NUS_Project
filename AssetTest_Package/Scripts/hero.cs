using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : MonoBehaviour
{
    private const float kHeroSpeed = 5f;  // 20-units in a second
    private float mHeroSpeed = kHeroSpeed;
    private Vector3 up=new Vector3(0f, 1f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q)){
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.W)){
            transform.position += transform.up * (mHeroSpeed * Time.smoothDeltaTime * 2);
        }
        if (Input.GetKey(KeyCode.A)){
            transform.position -= transform.right * (mHeroSpeed * Time.smoothDeltaTime);
        }
        if (Input.GetKey(KeyCode.D)){
            transform.position += transform.right * (mHeroSpeed * Time.smoothDeltaTime);
        }
        transform.up=up;
    }
}
