//using System.Threading.Tasks.Dataflow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AngoController : MonoBehaviour
{
    private static AngoController ins;
    // Start is called before the first frame update

    // private void Awake() {
        
    //     if(ins!=null && ins!=this)
    //         Destroy(gameObject);
    //     else
    //     {
    //         ins=this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    // }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
