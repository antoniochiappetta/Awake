using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    // Array of background tracks for each level
	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
		Debug.Log("Don't destroy on load: " + gameObject);
	}

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
        PlayerPrefsManager.SetMasterVolume(1.0f);
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}

	void OnLevelWasLoaded(int level)
	{
		// Play the audio clip corresponding the level loaded
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		Debug.Log("Level dd");
		if (thisLevelMusic) // If there's some music attached
		{
			Debug.Log("Level aaa");
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}

	public void ChangeVolume(float volume)
	{
		audioSource.volume = volume;
	}
}
