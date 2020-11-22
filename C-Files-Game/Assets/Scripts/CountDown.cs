using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    float currentTime = 0f;
    public int minute;
    public float sec;
    //public Text sec;
    public Text min;
    public MysteryChar character;
    bool timeUp;
    public GameObject smoke;
    
    // Start is called before the first frame update
    void Start()
    {
        currentTime = sec;
        timeUp = false;
        smoke.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (character.introCompleted() && !timeUp)
        {
            currentTime -= 1 * Time.deltaTime;

            if (currentTime < -0.5f && minute > 0)
            {
                minute -= 1;
                currentTime = 59f;
            }
            
            if(currentTime <= 9.5f) min.text = minute.ToString() + ":" + "0" + currentTime.ToString("0");
            else min.text = minute.ToString() + ":" + currentTime.ToString("0");
            //sec.text = currentTime.ToString("0");

        }

        if (minute == 0 && currentTime < 0)
        {
            timeUp = true;
            
        }
        if(minute == 0 && currentTime < 2) smoke.SetActive(true);
    }

    public int GetMin()
    {
        return minute;
    }

    public int GetSec()
    {
        int sec = (int)Mathf.Ceil(currentTime);
        return sec;
    }
}
