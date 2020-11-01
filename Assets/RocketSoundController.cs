using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSoundController : MonoBehaviour
{
    AudioSource rocketAudio;
    public AudioClip rocketSound;

    // Start is called before the first frame update
    void Start()
    {
        rocketAudio = GetComponent<AudioSource>();
    }

   

    void OnTriggerEnter(Collider col) {
        rocketAudio.PlayOneShot(rocketSound);
    }
}
