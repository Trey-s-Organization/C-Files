using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerScene : MonoBehaviour
{
    private void OnTrigger(Collider other)
    {
        SceneManager.LoadScene("End");
    }
}
