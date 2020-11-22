using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerBox : MonoBehaviour
{
    public Text text;
    private bool powerOn;
    private bool inTrigger;
    public MysteryChar character;
    bool audio;
    
    // Start is called before the first frame update
    void Start()
    {
        inTrigger = false;
        powerOn = false;
        
        audio = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<AudioSource>().enabled = audio;
        //text.text = "";
        if (Input.GetKeyDown(KeyCode.Return) && inTrigger && !powerOn)
        {
            audio = true;
            powerOn = true;
            text.text = "Power Activated";
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!powerOn && character.introCompleted())
        {
            text.text = "Press Enter To Activate Power";
            text.ToString();
        }
        
        inTrigger = true;
        


    }
    private void OnTriggerExit(Collider other)
    {
        text.text = "";
        text.ToString();
        inTrigger = false;
        
    }

    public bool PowerOn()
    {
        return powerOn;
    }

    
}
