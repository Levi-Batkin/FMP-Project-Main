using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
	public Sound[] sounds;
	[SerializeField] Slider music, sfx;
	public static float vol;
	AudioSource audioSource;
	public static float volume;
	
	void Awake()
	{
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.volume = music.value;
			s.source.clip = s.clip;
			s.source.pitch = 1;
		}
	}
	public void Start()
	{
		if(!PlayerPrefs.HasKey("music"))
		{
			PlayerPrefs.SetFloat("music", 1);
		}
		else
		{
			music.value = PlayerPrefs.GetFloat("music");
			Debug.Log("AudioManager.cs > Loaded audio float");
		}

		if(!PlayerPrefs.HasKey("sfx"))
		{
			PlayerPrefs.SetFloat("sfx", 1);
		}
		else
		{
			sfx.value = PlayerPrefs.GetFloat("sfx");
			Debug.Log("AudioManager.cs > Loaded SFX float");

		}
	}
	
	public void SaveMusic()
	{
        Debug.Log("AudioManager.cs > Music value set to "+ music.value);
		PlayerPrefs.SetFloat("music", music.value);
	}

	public void SaveSFX()
	{
		Debug.Log("AudioManager.cs > SFX value set to "+ sfx.value);
		PlayerPrefs.SetFloat("sfx", sfx.value);
	}

	public void Play(string name)
	{
		Debug.Log("Playing audio.");
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s == null)
		{
			Debug.Log("AudioManager.cs > Failed to find audio "+name);
		} 
		s.source.volume = PlayerPrefs.GetFloat("music", music.value);
		Debug.Log("AudioManager.cs > Played audio "+name);
		s.source.Play();
	}
	public void PlaySFX(string name)
	{
		Debug.Log("Playing audio.");
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s == null)
		{
			Debug.Log("AudioManager.cs > Failed to find audio "+name);
		}
		s.source.volume = PlayerPrefs.GetFloat("sfx", sfx.value);
		Debug.Log("AudioManager.cs > Played audio "+name);
		s.source.Play();
	}
	public void Stop(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s == null)
		{
			Debug.Log("AudioManager.cs > Failed to find audio "+name);
		}
		s.source.Stop();
        Debug.Log("AudioManager.cs > Stopped audio "+name);
	}
}

