using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	private static AudioSource audioSource;

  private static Dictionary<string, AudioClip> audioFiles;

  private void Start() {
		audioSource = GetComponent<AudioSource>();
	}

	public static void PlaySound(string file) {
    audioSource.PlayOneShot(audioFiles[file]);
  }

	public static void InitialiseAudio() {
    audioFiles = new Dictionary<string, AudioClip>();

    AudioClip loadedAudio = LoadAudio("SFX/block knock");
    audioFiles.Add("Knock", loadedAudio);

    loadedAudio = LoadAudio("SFX/Goal sound");
    audioFiles.Add("Goal", loadedAudio);

    loadedAudio = LoadAudio("SFX/selection back");
    audioFiles.Add("SelBack", loadedAudio);

    loadedAudio = LoadAudio("SFX/selection choose");
    audioFiles.Add("SelChoose", loadedAudio);

    loadedAudio = LoadAudio("SFX/selection switching");
    audioFiles.Add("SelSwitch", loadedAudio);

    loadedAudio = LoadAudio("SFX/short_triumph");
    audioFiles.Add("Triumph", loadedAudio);
  }

  private static AudioClip LoadAudio(string filepath) {
		AudioClip audio = Resources.Load<AudioClip>("Audio/" + filepath);
		if (audio == null) {
			Debug.LogError("Error loading audio, path = [" + filepath + "]");
		}
		return audio;
	}
}
