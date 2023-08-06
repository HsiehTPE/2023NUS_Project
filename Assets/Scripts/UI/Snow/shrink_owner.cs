using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shrink_owner : MonoBehaviour
{
    public string[] sentences; 
    public string[] sentences2; // not first time 
    private int index;
    private int index2;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject TextPlane;
    public GameObject shrink_img;
    public Main_Charactor ango;
    public bool first_talk = true;
    public TextMeshProUGUI textDisplay;


    IEnumerator Type()
    {
        if(!first_talk)
        {
            // print("2");
            foreach(char letter in sentences2[index2].ToCharArray())
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(0.02f);
            }
        }

        else
        {
            // print("1");
            foreach(char letter in sentences[index].ToCharArray())
            {
                if(index==3 && first_talk)
                {
                    shrink_img.SetActive(true);
                    ango.get_shrink = true;
                }
                textDisplay.text += letter;
                yield return new WaitForSeconds(0.02f);
            }
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if(first_talk && index < sentences.Length-1)
        {
            index ++;
            textDisplay.text = "";
            StartCoroutine(Type());
            if(index==4)
            {
                first_talk = false; 
            }
            // print("index1"+index);    
        }
        else if(!first_talk && index2 < sentences2.Length-1)
        {
            index2 ++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            if(index==4) shrink_img.SetActive(false);
            textDisplay.text = "";
            continueButton.SetActive(false);
            TextPlane.SetActive(false);
            // 2
            // Time.timeScale = 1f; 
        }
    }

    void OnEnable()
    {
        index = 0; index2 = 0;
        StartCoroutine(Type());
        // index = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        // print(sentences2.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if(textDisplay.text == sentences[index] || textDisplay.text == sentences2[index2])
        {
            continueButton.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                NextSentence();
            }
        }
    }
}
