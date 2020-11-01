using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSoundController : MonoBehaviour
{
    AudioSource fireAudio;
    public AudioClip fireSound;

    // Start is called before the first frame update
    void Start()
    {
        fireAudio = GetComponent<AudioSource>();
        fireAudio.PlayOneShot(fireSound);
    }

    
}
