using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public string scene;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(scene);
    }
}
