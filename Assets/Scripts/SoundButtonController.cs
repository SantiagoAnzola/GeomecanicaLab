using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButtonController : MonoBehaviour
{
    private AudioSource sound;
    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    public void PlaySound()
    {
        sound.Play();
    }
}
