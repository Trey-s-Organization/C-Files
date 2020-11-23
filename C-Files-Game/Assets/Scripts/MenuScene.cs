using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Code by Julius Scott

public class MenuScene : MonoBehaviour
{
    public void changemenuscene(string Menu)
    {
        //Application.LoadLevel(Menu);
        SceneManager.LoadScene(Menu);
    }

    private void Update()
    {
        
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
