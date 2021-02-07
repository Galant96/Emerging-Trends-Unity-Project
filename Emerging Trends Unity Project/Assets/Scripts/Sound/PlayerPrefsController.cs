using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class manages and saves player preferences.
/// </summary>
public class PlayerPrefsController : MonoBehaviour
{
	const string MASTER_SOUND_VOLUME_KEY = "master sound volume";
	const float MIN_SOUND_VOLUME = 0f;
	const float MAX_SOUND_VOLUME = 1f;

	const string MASTER_MUSIC_VOLUME_KEY = "master music volume";
	const float MIN_MUSIC_VOLUME = 0f;
	const float MAX_MUSIC_VOLUME = 1f;

	/// <summary>
	/// Sets the master volume.
	/// </summary>
	/// <param name="volume">The new master volume value.</param>
	public static void SetMasterSoundVolume(float volume)
	{
		if (volume >= MIN_SOUND_VOLUME && volume <= MAX_SOUND_VOLUME)
		{
			PlayerPrefs.SetFloat(MASTER_SOUND_VOLUME_KEY, volume);
			Debug.LogError("Master sound volume set to " + volume);
		}
		else
		{
			Debug.LogError("Master sound volume is out of range");
		}
	}

	/// <summary>
	/// Gets the value of the master volume.
	/// </summary>
	public static float GetMasterSoundVolume()
	{
		return PlayerPrefs.GetFloat(MASTER_SOUND_VOLUME_KEY);
	}

	/// <summary>
	/// Sets the master volume of the music.
	/// </summary>
	/// <param name="volume">The new volume of the music.</param>
	public static void SetMasterMusicVolume(float volume)
	{
		if (volume >= MIN_MUSIC_VOLUME && volume <= MAX_MUSIC_VOLUME)
		{
			PlayerPrefs.SetFloat(MASTER_MUSIC_VOLUME_KEY, volume);
			Debug.LogError("Master music volume set to " + volume);
		}
		else
		{
			Debug.LogError("Master music volume is out of range");
		}
	}

	/// <summary>
	/// Gets the value of the music volume.
	/// </summary>
	public static float GetMasterMusicVolume()
	{
		return PlayerPrefs.GetFloat(MASTER_MUSIC_VOLUME_KEY);
	}

}
