using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class switch_scene : MonoBehaviour
{
    public 
    // Start is called before the first frame update
    void Start()
    {
 
    }
 
    // Update is called once per frame
    void Update()
    {
        //点击鼠标右键切换场景
 
    }

    public void change_scene()
    {
        SceneManager.LoadScene("origin_villiage");
    }

    public void change_to_levelone()
    {
        SceneManager.LoadScene("level_one");
    }
}