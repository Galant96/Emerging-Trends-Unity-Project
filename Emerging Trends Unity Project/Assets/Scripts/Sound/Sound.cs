using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// This class describes the features of a sound. It can be used to implement various sounds in the application.
/// </summary>
[System.Serializable]
public class Sound
{
	[SerializeField]
	private string soundName;
	public string SoundName
	{
		get { return soundName; }
		set { soundName = value; }
	}

	[SerializeField]
	private AudioClip clip; // Gets/Sets an audio file of the recorded sound
	public AudioClip Clip
	{
		get { return clip; }
		set { clip = value; }
	}

	[SerializeField, Range(0f, 1f)]
	private float volume = 0.7f; // Gets/Sets the volume
	public float Volume
	{
		get { return volume; }
		set { volume = value; }
	}

	[SerializeField, Range(0f, 3f)]
	private float pitch = 1f; // Gets/Sets the pitch
	public float Pitch
	{
		get { return pitch; }
		set { pitch = value; }
	}

	[SerializeField]
	private bool loop = false; // Gets/Sets the loop (If true the sound is played in a loop)
	public bool Loop
	{
		get { return loop; }
		set { loop = value; }
	}

	[HideInInspector]
	private AudioSource audioSource; // Gets/Sets the Audio Source
	public AudioSource AudioSource
	{
		get { return audioSource; }
		set { audioSource = value; }
	}
}
