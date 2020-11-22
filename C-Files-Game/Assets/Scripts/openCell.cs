using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openCell : MonoBehaviour
{
    public GameObject door;
    
    private bool trip;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        trip = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<AudioSource>().enabled = trip;
        if (trip && door.transform.position.y > -12)
        {
            door.transform.Translate(0, -Time.deltaTime, 0);
            
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        trip = true;

    }
}
