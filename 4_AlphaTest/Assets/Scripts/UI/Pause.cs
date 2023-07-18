using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu = null;
    private bool pauseflag = false;
    private bool cooldown = false;
    private int init_cooldown = 100;
    private int cooling_time = 100;
    // Start is called before the first frame update
    void Start()
    {
        // cooling_time = init_cooldown;
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        check_cooldown();
        enablePause();
        unablePause();   
    }

    void enablePause()
    {
        if(Input.GetKey(KeyCode.P) && !pauseflag)
        {
            PauseMenu.SetActive(true);
            pauseflag = true;
            Time.timeScale = 0f; 
            cooldown = true;
            print("a");
        }
    }

    void unablePause()
    {
        if(Input.GetKey(KeyCode.P) && pauseflag && !cooldown)
        {
            PauseMenu.SetActive(false);
            pauseflag = false;
            Time.timeScale = 1f;
            print("b");
        }
    }

    void check_cooldown()
    {
        if(cooldown)
        {
            cooling_time --;
        }
        if(cooling_time <= 0)
        {
            cooldown = false;
            cooling_time = init_cooldown;
            print("cooltime"+cooling_time);
        }
    }

    public void click_unpause()
    {
        PauseMenu.SetActive(false);
        pauseflag = false;
        Time.timeScale = 1f;
    }
}
