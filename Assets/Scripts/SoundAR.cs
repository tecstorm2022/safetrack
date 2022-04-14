using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAR : MonoBehaviour
{
    public AudioSource heartSound;
    public GameObject heart;

    private bool sound;
    
    // Start is called before the first frame update
    void Start()
    {
        sound = false;
    }

    // Update is called once per frame
    void Update()
    {
        MeshRenderer m = heart.GetComponent<MeshRenderer>();
        if (m.enabled)
        {
            if (!sound)
            {
                Debug.Log("START");
                heartSound.Play();
                sound = true;
            }
            
        }
        else
        {
            heartSound.Stop();
            sound = false;
        }
    }
}
