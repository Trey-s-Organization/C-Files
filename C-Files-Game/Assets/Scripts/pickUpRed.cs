using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickUpRed : MonoBehaviour
{
    public Text code;
    public Text interact;
    bool inTrigger;
    public PlayerController player;
    bool cardOpened;
    public GameObject save;
    public string color;
    public string inputCode;
    public int yCord;
    public GameObject redCard;

    // Start is called before the first frame update
    void Start()
    {
        inTrigger = false;
        cardOpened = false;
        save.SetActive(false);
        redCard.SetActive(true);
    }

    private void Update()
    {
        if (inTrigger)
        {
            if (!cardOpened) interact.text = "Press 'E' open card";

            if (Input.GetKey(KeyCode.E))
            {
                save.SetActive(true);
                cardOpened = true;
                interact.text = "";
                player.Interact();
                code.text = inputCode;

            }
        }
        else
        {
            interact.text = "";
        }
    }

    public void Save()
    {
        player.Resume();
        save.SetActive(false);
        code.text = color + " CODE: " + inputCode;
        code.transform.localPosition = new Vector3(-600, yCord, 0);
        redCard.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;

    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }
    public bool InTrigger()
    {
        return inTrigger;
    }
}
