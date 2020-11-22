using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SmokeAlarm : MonoBehaviour
{
    public PlayerController player;
    AudioSource alarm;
    // Start is called before the first frame update
    void Start()
    {
        alarm = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Alarm());
    }

    IEnumerator Alarm()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
        player.playerSen();
    }
}
