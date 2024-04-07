using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3;

    public void Butt1()
    {
        src.clip = sfx1;
        src.Play();
    }
    public void Butt2()
    {
        src.clip = sfx2;
        src.Play();
    }
    public void Butt3()
    {
        src.clip = sfx3;
        src.Play();
    }
}
