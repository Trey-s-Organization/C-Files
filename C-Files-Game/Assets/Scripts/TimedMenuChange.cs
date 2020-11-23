using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedMenuChange : MonoBehaviour
{
       // Code by Julius Scott
    
    // Declare Variables

    public string Level;
    private float timer = 10f;

    // Update is called once per frame
    void Update()
    {

     timer -= Time.deltaTime;
     if (timer <= 0)
     {
         Application.LoadLevel(Level);
     }

    }
}
