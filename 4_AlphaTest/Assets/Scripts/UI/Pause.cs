using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu = null;
    private bool pauseflag = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!pauseflag)
            {
                print("p2"+pauseflag);
                // PauseGame();
                PauseMenu.SetActive(true);
                Time.timeScale = 0f;
                pauseflag = true;
                print("p2"+pauseflag);
            }
            else
            {
                print("p1"+pauseflag);
                // ResumeGame();
                Time.timeScale = 1f;
                pauseflag = false;
                PauseMenu.SetActive(false);
                print("p1"+pauseflag);
            }
        }

    }


    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pauseflag = true;
    }
 
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseflag = false;
        PauseMenu.SetActive(false);
    }

    public void click_unpause()
    {
        print("p3"+pauseflag);
        PauseMenu.SetActive(false);
        pauseflag = false;
        Time.timeScale = 1f;
        print("p3"+pauseflag);
    }
}
