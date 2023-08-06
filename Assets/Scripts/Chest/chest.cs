using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    public Main_Charactor ango=null;
    public GameObject hero=null;
    public GameObject template=null;
    public GameObject dialog;
    private float delta=3f;
    private float colorminus=0.7f;
    public bool UI=false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(ango!=null);
        Debug.Assert(hero!=null);
    }

    void Update()
    {
        float dist = Vector3.Distance(hero.transform.localPosition, transform.localPosition);
        if(dist<delta){
            UI=true;
            if(Input.GetKey(KeyCode.E))
            {
                UI=false;
                GenerateEmpytChest();
                if(Input.GetKeyDown(KeyCode.E))
                {
                    dialog.SetActive(true);
                }
            }
        }
    }

    private void GenerateEmpytChest()
    {
        ango.gm.numKey++;
        template = Resources.Load<GameObject>("Prefabs/emptychest");
        GameObject p = GameObject.Instantiate(template) as GameObject;
        p.transform.position=transform.position;
        Destroy(gameObject);
    }
}
