using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charTrigger : MonoBehaviour
{
    bool inTrigger;
    AudioSource source;
    public AudioClip heyYou;
    bool intro = false;
    bool audioPlaying;
    // Start is called before the first frame update
    void Start()
    {
        inTrigger = false;
        source = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inTrigger && !intro)
        {
            source.PlayOneShot(heyYou);
            intro = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }

    public bool Trigger()
    {
        return inTrigger;
    }

    public bool isPlaying()
    {
        audioPlaying = source.isPlaying;
        return audioPlaying;
    }
}
