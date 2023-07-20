using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class switch_scene : MonoBehaviour
{
    // public opening_transition o;
    // Start is called before the first frame update
    void Start()
    {
 
    }
 
    // Update is called once per frame
    void Update()
    {
        //点击鼠标右键切换场景
        // if (o.T)
 
    }

    public void change_scene_main()
    {
        SceneManager.LoadScene("Main");
    }

    public void change_scene_village()
    {
        SceneManager.LoadScene("origin_villiage");
    }

    public void change_to_levelone()
    {
        SceneManager.LoadScene("level_one");
    }

    public void quit_game()
    {
        //编辑器中退出游戏
        #if UNITY_EDITOR 
            UnityEditor.EditorApplication.isPlaying = false;
        //应用程序中退出游戏
        #else 
            UnityEngine.Application.Quit();
        #endif
    }
}