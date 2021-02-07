using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for handling sounds effects in the application.
/// /// </summary>
public class SoundManager : MonoBehaviour
{
	// Instance of the class
	public static SoundManager Instance { get; private set; }

	[SerializeField]
	public List<Sound> sounds = null; // List of all used sounds

	[SerializeField]
	public Sound musicSound = null; // Place for the main music

	private void Awake()
	{
		// Set up the instance
		SetUpSingelton();

		// Set up all sounds
		foreach (Sound sound in sounds)
		{ 
			// If the sound is the main music
			if (sound.SoundName == "Music")
			{
				musicSound = sound; // Sets sound
				sound.AudioSource = gameObject.AddComponent<AudioSource>(); // Adds AudioSource component 
				sound.AudioSource.clip = sound.Clip; // Sets clip

				sound.AudioSource.volume = PlayerPrefsController.GetMasterMusicVolume();
				sound.AudioSource.pitch = sound.Pitch;
				sound.AudioSource.loop = sound.Loop;
			}
			else
			{
				sound.AudioSource = gameObject.AddComponent<AudioSource>(); // Adds AudioSource component 
				sound.AudioSource.clip = sound.Clip;// Sets clip

				sound.AudioSource.volume = PlayerPrefsController.GetMasterSoundVolume();
				sound.AudioSource.pitch = sound.Pitch;// Sets pitch
				sound.AudioSource.loop = sound.Loop;// Sets loop
			}
			
		}
	}

	/// <summary>
	/// Gets sound by name.
	/// /// </summary>
	/// <param name="name"> The name of the sound. </param>
	public Sound GetSound(string name)
	{
		return sounds.Find(sounds => sounds.SoundName == name);
	}

	/// <summary>
	/// Gets the main music sound.
	/// </summary>
	public Sound GetMusic()
	{
		return sounds.Find(sounds => sounds.SoundName == "Music");
	}

	/// <summary>
	/// Playing sound by name.
	/// </summary>
	/// <param name="name">The name of the sound.</param>
	public void PlaySound(string name)
	{
		if (sounds != null)
		{
			// Gets the sound to play
			Sound sound = sounds.Find(sounds => sounds.SoundName == name);

			if (sound == null)
			{
				Debug.Log("The sound " + name + (" has not been assigned!"));
				return;
			}

			sound.AudioSource.Play();
		}
	}

	/// <summary>
	/// Pausing sound by name.
	/// </summary>
	/// <param name="name">The name of the sound.</param>
	public void PauseSound(string name)
	{
		if (sounds != null)
		{
			// Get the sound to play
			Sound sound = sounds.Find(sounds => sounds.SoundName == name);

			if (sound == null)
			{
				Debug.Log("The sound " + name + (" has not been assigned!"));
				return;
			}

			sound.AudioSource.Pause();
		}
	}

	/// <summary>
	///	Pausing all sounds.
	/// </summary>
	public void PauseAllSounds()
	{
		foreach (Sound sound in sounds)
		{
			sound.AudioSource.Pause();
		}
	}

	/// <summary>
	/// Sets up the object's instance to prevent duplication of the object while the program is running.
	 /// </summary>
	private void SetUpSingelton()
	{

		// If the instance of the object is null then keep the previous object
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else // else destroy the new object and keep "the old" one

		{
			Destroy(gameObject);
		}
	}

}
