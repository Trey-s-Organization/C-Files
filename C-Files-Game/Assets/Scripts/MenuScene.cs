using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Code by Julius Scott

public class MenuScene : MonoBehaviour
{
    public void changemenuscene(string Menu)
    {
        Application.LoadLevel(Menu);
    }
  
}
