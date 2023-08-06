using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switch_scene : MonoBehaviour
{
    // public opening_transition o;
    // Start is called before the first frame update
    public GameObject ango;
    public Animator transitionAnim;
    public string scene_village;
    public string scene_main;
    public string scene_snow;
    public string scene_opening;
    public string scene_cave;
    public string scene_castle;

    void Start()
    {

    }
 
    // Update is called once per frame
    void Update()
    {
 
    }
    public void startopen()
    {
        StartCoroutine(LoadOpen());
    }

    public void startvillage()
    {
        StartCoroutine(LoadVillage());
    }

    public void startmain()
    {
        Time.timeScale = 1f; 
        StartCoroutine(LoadMain());
    }

    public void startsnow()
    {
        // Time.timeScale = 1f; 
        StartCoroutine(LoadSnow());
    }

    public void startcave()
    {
        // Time.timeScale = 1f; 
        StartCoroutine(LoadCave());
    }

    public void startcastle()
    {
        // Time.timeScale = 1f; 
        StartCoroutine(LoadCastle());
    }

    public void open_start()
    {
        StartCoroutine(open_LoadVillage());
    }


    // Loading
    IEnumerator LoadOpen()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(scene_opening);
    }


    IEnumerator open_LoadVillage()
    {
        transitionAnim.Play("open_end");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(scene_village);
    } 

    IEnumerator LoadVillage()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(scene_village);
    }

    IEnumerator LoadMain()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(scene_main);
    }

    IEnumerator LoadSnow()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(scene_snow);       
    }

    IEnumerator LoadCave()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(scene_cave);       
    }

    IEnumerator LoadCastle()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(scene_castle);       
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

    public void change_to_leveltwo()
    {
        SceneManager.LoadScene("level_two");
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