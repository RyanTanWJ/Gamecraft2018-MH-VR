using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	private AudioSource audioSource;

	private void Start() {
		audioSource = GetComponent<AudioSource>();
	}

	private static Dictionary<string, AudioClip> audioFile;

	public void PlaySound(string file) {
		audioSource.PlayOneShot(audioFile[file]);
	}

	public static void initialiseAudio() {
		audioFile = new Dictionary<string, AudioClip>();
	}

	private static AudioClip LoadAudio(string filepath) {
		AudioClip audio = Resources.Load<AudioClip>("Audio/" + filepath);
		if (audio == null) {
			Debug.LogError("Error loading audio, path = [" + filepath + "]");
		}
		return audio;
	}
}
