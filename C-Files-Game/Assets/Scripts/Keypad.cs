using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Keypad : MonoBehaviour
{
    public GameObject door;
    bool inTrigger;
    public Text text;
    public GameObject keypad;
    public PlayerController player;
    public Text userInput;
    string interact;
    bool unlock = false;
    public powerBox pwrBox;
    AudioSource source;
    public AudioClip click;
    public AudioClip buzzer;
    public AudioClip fail;
    
    
    // Start is called before the first frame update
    void Start()
    {
        inTrigger = false;
        keypad.SetActive(false);
        interact = "Press 'E' to login";
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inTrigger && pwrBox.PowerOn())
        {
            text.text = interact;
            if (Input.GetKeyDown(KeyCode.E))
            {
                interact = "";
                keypad.SetActive(true);
                player.Interact();
            }
        }
        else
        {
            text.text = "";
            interact = "Press 'E' to interact";
        }

        if(unlock) door.transform.Translate(0, Time.deltaTime, 0);

    }

    public void Unlock()
    {
        source.PlayOneShot(click);
        if (userInput.text == "JENNY")
        {
            source.PlayOneShot(buzzer);
            unlock = true;
        }
        else
        {
            source.volume = 0.5f;
            source.PlayOneShot(fail);
        }
        keypad.SetActive(false);
        player.Resume();
    }

    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        
    }
}
