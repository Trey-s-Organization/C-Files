using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MysteryChar : MonoBehaviour
{
    bool inTrigger;
    public Text text;
    string[] dialogue;
    string filePath, fileName;
    int i = 0;
    bool introComplete;
    public CountDown gameTime;
    AudioSource source;
    public AudioClip threeMin;
    public AudioClip noTime;
    public AudioClip death;
    public PlayerController player;
    public GameObject gameOver;
    public GameObject mouse1;
    public charTrigger charTrigger;
    

    
    
    // Start is called before the first frame update
    void Start()
    {
        inTrigger = false;
        fileName = "Dialogue.txt";
        filePath = Application.dataPath + "/" + fileName;
        ReadFromfile();
        introComplete = false;
        source = GetComponent<AudioSource>();
        source.enabled = false;
        gameOver.SetActive(false);
        mouse1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (source.isPlaying == false)
        {
            source.enabled = false;
            
        }

        ThreeMinLeft();
        NoTime();
        Death();
        


        if (inTrigger && !charTrigger.isPlaying())
        {
            text.text = dialogue[i];
            mouse1.SetActive(true);
            if (Input.GetMouseButton(0) && i < dialogue.Length - 1)  i++;  
        }
        else { text.text =  ""; mouse1.SetActive(false); }
        if (i == dialogue.Length - 1) introComplete = true;
  
        

    }

    public void ReadFromfile()
    {
        dialogue = File.ReadAllLines(filePath);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        inTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        
        inTrigger = false;
    }
    public bool introCompleted()
    {
        return introComplete;
    }

    private void ThreeMinLeft()
    {
        if (gameTime.GetMin() == 2 && gameTime.GetSec() == 59)
        {
            source.clip = threeMin;
            source.volume = 0.3f;
            source.enabled = true;
        }
    }

    private void NoTime()
    {
        if (gameTime.GetMin() == 0 && gameTime.GetSec() == 59)
        {
            source.clip = noTime;
            source.volume = 0.3f;
            source.enabled = true;

        }
    }

    private void Death()
    {
        if (gameTime.GetMin() == 0 && gameTime.GetSec() == 1)
        {
            source.clip = death;
            source.volume = 0.3f;
            source.enabled = true;
            StartCoroutine(ExampleCoroutine());
        }
    }

    IEnumerator ExampleCoroutine()
    {        
        yield return new WaitForSeconds(3);
        Time.timeScale = 0.1f;
        player.Death();
        gameOver.SetActive(true);
    }
}
