// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class NewBehaviourScript : MonoBehaviour
// {
//     public GameObject triggered_object;
//     public GameObject triggered_hint = null;
//     public GameObject dialog = null;
//     private bool hint = false; 

//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(hint)
//         {
//             if(Input.GetKeyDown(KeyCode.E))
//             {
//                 dialog.SetActive(true);
//             }
//         }
//     }

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if(collision.tag == "Ango")
//         {
//             mTrigger_hint = Resources.Load<GameObject>("Prefabs/trigger_hint");
//             GameObject T = GameObject.Instantiate(mTrigger_hint) as GameObject;
//             T.transform.localPosition = transform.localPosition + new Vector3(0f, 2f, -1f);
//             hint = true;
//         }
//     }

//     private void OnTriggerExit2D(Collider2D collision)
//     {
//         if(collision.tag == "Ango")
//         {
//             Destroy(T);
//             hint = false;
//         }
//     }
// }
