using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class laptop : MonoBehaviour
{
    public powerBox pwrBox;
    public Text text;
    private string userInput, password, decryptInput;
    public GameObject inputField;
    public GameObject decryptField;
    bool inTrigger;
    public PlayerController player;
    public GameObject login;
    public GameObject decrypt;
    bool loginAttempt;
    bool active;
    public Text incorrect;
    public Text result;
    public string decryptedCode;
    public AudioClip fail;
    public AudioClip hint;
    
    AudioSource source;
    public AudioClip click;
    bool hintPlayed;
    
    // Start is called before the first frame update
    void Start()
    {
        inTrigger = false;
        password = "bobcat";
        login.SetActive(false);
        loginAttempt = false;
        decrypt.SetActive(false);
        active = false;
        incorrect.text = "";
        source = GetComponent<AudioSource>();
        hintPlayed = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(inTrigger && pwrBox.PowerOn())
        {
            text.text = "Press 'E' to login";
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                active = true;
                //disable movement
                player.Interact();
                //activate login screen
              
                login.SetActive(true);
                
            }
            if (loginAttempt && active)
            {
                incorrect.text = "";
                login.SetActive(false);
                decrypt.SetActive(true);
            }
        }
        if (inTrigger && !pwrBox.PowerOn() && !hintPlayed) { source.volume = 1; source.PlayOneShot(hint); hintPlayed = true; }
    }

    public void StoreName()
    {
        source.PlayOneShot(click);
        userInput = inputField.GetComponent<Text>().text;
        userInput = userInput.ToLower();
        if (userInput == password) loginAttempt = true;
        else
        {
            incorrect.text = "INCORRECT";
            source.PlayOneShot(fail);
        }
        
        
        
    }

    public void Decrypt()
    {
        decryptInput = decryptField.GetComponent<Text>().text;
        source.PlayOneShot(click);
        if (decryptInput == decryptedCode)
        {
            result.color = Color.green;
            result.text = "Decryption Code: 'JENNY'";
        }
        else
        {
            result.color = Color.red;
            result.text = "NO RESULT";
        }
    }

    

    public void Exit()
    {
        login.SetActive(false);
        decrypt.SetActive(false);
        active = false;
        loginAttempt = false;
        player.Resume();
        
        source.PlayOneShot(click);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!pwrBox.PowerOn()){
            text.text = "Power Disconnected";
            text.ToString();
        }
        inTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        text.text = "";
        inTrigger = false;
    }
}
