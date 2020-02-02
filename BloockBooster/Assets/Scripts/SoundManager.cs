using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public AudioSource background;
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioClip[] clips;


    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlayBackground(int index)
    {
        background.clip = clips[index];
        background.Play();
    }

    public void PlaySound(int index)
    {
        if (sound1.isPlaying)
        {
            sound2.clip = clips[index];
            sound2.Play();
        }
        else
        {
            sound1.clip = clips[index];
            sound1.Play();
        }
    }
}
