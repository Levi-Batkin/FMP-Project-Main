using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicController : MonoBehaviour
{
    public AudioSource backgroundsrc;
    float musicvol;
    public AudioSource sfxsrc;
    float sfxvol;
    // Start is called before the first frame update
    void Start()
    {
        musicvol = PlayerPrefs.GetFloat("music");
        backgroundsrc.volume = musicvol;
        sfxvol = PlayerPrefs.GetFloat("sfx");
        sfxsrc.volume = sfxvol;
    }

}
