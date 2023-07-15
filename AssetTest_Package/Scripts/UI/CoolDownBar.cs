using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownBar : MonoBehaviour
{
    public float mSecToCoolDown = 0.2f;
    private float mLastTriggered = 0f;
    private bool mActive = false;
    private float mInitBarWidth = 0f;

    // Start is called before the first frame update
    void Start()
    {
        RectTransform r = GetComponent<RectTransform>();
        mInitBarWidth = r.sizeDelta.x;  // This is the width of the Rect Transform
        mLastTriggered = Time.time; // time last triggered
        Vector2 s = GetComponent<RectTransform>().sizeDelta;
        s.x = 0f;
        GetComponent<RectTransform>().sizeDelta = s;
        // Renderer renderer = GetComponent<Renderer>();
        // renderer.isVisible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mActive)
        {
            // Vector2 s = GetComponent<RectTransform>().sizeDelta;
            // s.x = mInitBarWidth;
            // GetComponent<RectTransform>().sizeDelta = s;
            UpdateCoolDownBar();
        }
        else if(!mActive)
        {
            Vector2 s = GetComponent<RectTransform>().sizeDelta;
            s.x = 0f;
            GetComponent<RectTransform>().sizeDelta = s;
        }

    }

    private void UpdateCoolDownBar()
    {

        float sec = SecondsTillNext();
        float percentage = sec / mSecToCoolDown;

        if (sec < 0)
        {
            mActive = false;
            percentage = 1.0f;
        }
            
        Vector2 s = GetComponent<RectTransform>().sizeDelta;
        s.x = percentage * mInitBarWidth;
        GetComponent<RectTransform>().sizeDelta = s;

        // mInitBarWidth = 0;  // This is the width of the Rect Transform
    }

    public void SetCoolDownLength(float s)
    {
        mSecToCoolDown = s;
    }

    private float SecondsTillNext()
    {
        float secLeft = -1;
        if (mActive)
        {
            float sinceLast = Time.time - mLastTriggered;
            secLeft = mSecToCoolDown - sinceLast;
        }
        return secLeft;
    }

    // returns if trigger is successful
    public bool TriggerCoolDown()
    {
        bool canTrigger = !mActive;
        if (canTrigger)
        {
            mActive = true;
            mLastTriggered = Time.time;
            UpdateCoolDownBar();
        }
        return canTrigger;
    }

    // public void SetActive(bool status)
    // {

    // }

    public bool ReadyForNext()
    {
        return (!mActive);
    }
}
