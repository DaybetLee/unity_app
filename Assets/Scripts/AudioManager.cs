using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource[] bgm;
    public AudioSource[] sfx;
    public bool musicPlay = true;
    public bool sfxPlay = true;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        if (musicPlay == false)
        {
            StopMusic();
        }
    }

    public void PlaySFX(int soundToPlay)
    {
        if (sfxPlay == true)
        {
            if (soundToPlay < sfx.Length)
            {
                sfx[soundToPlay].Play();
            }
        }
    }

    public void PlayBGM(int musicToPlay)
    {
        if (musicPlay == true)
        {
            if (!bgm[musicToPlay].isPlaying)
            {
                StopMusic();

                if (musicToPlay < bgm.Length)
                {
                    bgm[musicToPlay].Play();

                }
            }
        }
    }

    public void StopMusic()
    { 
        for(int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }

    public void BGMSwitch(bool input)
    {
        musicPlay = input;
    }
    
    public void SFXSwitch(bool input)
    {
        sfxPlay = input;
    }
}
