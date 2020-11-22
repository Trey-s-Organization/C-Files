using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchScene : MonoBehaviour
{
    //public int sceneTo;
    public string scene;


    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(scene);
    }
}
