using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platup : MonoBehaviour
{
    private float posx,posy,posz;
    // Start is called before the first frame update
    void Start()
    {
        posx=transform.position.x;
        posz=transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        posy=transform.position.y;
        transform.position=new Vector3(posx,posy,posz);
    }
}
