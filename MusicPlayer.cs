using UnityEngine;
using System.Collections;

/// <summary>
/// This script is in charge of playing music in the game
/// </summary>
public class MusicPlayer : MonoBehaviour
{
	/// <summary>
	/// The clip to play in a menu.
	/// This field is private because it's not designed to be directly
	/// modified by other scripts, and tagged with [SerializeField] so that
	/// you can still modify it using the Inspector and so that Unity
	/// saves its value.
	/// </summary>
	[SerializeField]
	private AudioClip menuMusic;

	[SerializeField]
	private AudioClip menuMusicLoop;

	/// <summary>
	/// The clip to play outside menus.
	/// </summary>
	[SerializeField]
	private AudioClip overworldMusic;

	[SerializeField]
	private AudioClip enemyFollowingMusic;

	[SerializeField]
	private AudioClip enemyEncounterMusic;

	[SerializeField]
	private AudioClip postBattleMusic;

	[SerializeField]
	private AudioClip gameMenuMusic;

	[SerializeField]
	private AudioClip startGameSound;

	/// <summary>
	/// The component that plays the music
	/// </summary>
	[SerializeField]
	private AudioSource musicSource;

	[SerializeField]
	private AudioSource sfxSource;



	/// <summary>
	/// This class follows the singleton pattern and this is its instance
	/// </summary>
	static private MusicPlayer instance;

	/// <summary>
	/// Awake is not public because other scripts have no reason to call it directly,
	/// only the Unity runtime does (and it can call protected and private methods).
	/// It is protected virtual so that possible subclasses may perform more specific
	/// tasks in their own Awake and still call this base method (It's like constructors
	/// in object-oriented languages but compatible with Unity's component-based stuff.
	/// </summary>
	protected virtual void Awake() {
		// Singleton enforcement
		if (instance == null) {
			// Register as singleton if first
			instance = this;
			DontDestroyOnLoad(this);
		} else {
			// Self-destruct if another instance exists
			Destroy(this);
			return;
		}
	}

	protected virtual void Start() {
		// If the game starts in a menu scene, play the appropriate music
		PlayMenuMusic();
	}

	void Update() {
		if(!instance.musicSource.isPlaying && instance.musicSource.clip == instance.menuMusic) {
			PlayMenuMusicLoop ();
		}
	}

	/// <summary>
	/// Plays the music designed for the menus
	/// This method is static so that it can be called from anywhere in the code.
	/// </summary>
	static public void PlayMenuMusic ()
	{
		if (instance != null) {
			if (instance.musicSource != null) {
				instance.musicSource.Stop();
				instance.musicSource.clip = instance.menuMusic;
				instance.musicSource.Play();
			}
		} else {
			Debug.LogError("Unavailable MusicPlayer component");
		}
	}

	static public void PlayMenuMusicLoop ()
	{
		if (instance != null) {
			if (instance.musicSource != null) {
				instance.musicSource.Stop();
				instance.musicSource.clip = instance.menuMusicLoop;
				instance.musicSource.loop = true;
				instance.musicSource.Play();
			}
		} else {
			Debug.LogError("Unavailable MusicPlayer component");
		}
	}

	/// <summary>
	/// Plays the music designed for outside menus
	/// This method is static so that it can be called from anywhere in the code.
	/// </summary>
	static public void PlayOverworldMusic ()
	{
		if (instance != null) {
			if (instance.musicSource != null && instance.musicSource.clip != instance.overworldMusic) {
				instance.musicSource.Stop();
				instance.musicSource.clip = instance.overworldMusic;
				instance.musicSource.Play();
			}
		} else {
			Debug.LogError("Unavailable MusicPlayer component");
		}
	}

	static public void PlayEnemyFollowingMusic ()
	{
		if (instance != null) {
			if (instance.musicSource != null && instance.musicSource.clip != instance.enemyFollowingMusic) {
				instance.musicSource.Stop();
				instance.musicSource.clip = instance.enemyFollowingMusic;
				instance.musicSource.Play();
			}
		} else {
			Debug.LogError("Unavailable MusicPlayer component");
		}
	}

	static public void PlayEnemyEncounterMusic ()
	{
		if (instance != null) {
			if (instance.musicSource != null && instance.musicSource.clip != instance.enemyEncounterMusic) {
				instance.musicSource.Stop();
				instance.musicSource.clip = instance.enemyEncounterMusic;
				instance.musicSource.Play();
			}
		} else {
			Debug.LogError("Unavailable MusicPlayer component");
		}
	}

	static public void PlayPostBattleMusic ()
	{
		if (instance != null) {
			if (instance.musicSource != null && instance.musicSource.clip != instance.postBattleMusic) {
				instance.musicSource.Stop();
				instance.musicSource.clip = instance.postBattleMusic;
				instance.musicSource.Play();
			}
		} else {
			Debug.LogError("Unavailable MusicPlayer component");
		}
	}

	static public void PlayGameMenuMusic ()
	{
		if (instance != null) {
			if (instance.musicSource != null && instance.musicSource.clip != instance.gameMenuMusic) {
				instance.musicSource.Stop();
				instance.musicSource.clip = instance.gameMenuMusic;
				instance.musicSource.Play();
			}
		} else {
			Debug.LogError("Unavailable MusicPlayer component");
		}
	}

	static public void PlayStartGameSound ()
	{
		if (instance != null) {
			if (instance.sfxSource != null) {
				instance.sfxSource.Stop();
				instance.sfxSource.clip = instance.startGameSound;
				instance.sfxSource.Play();
			}
		} else {
			Debug.LogError("Unavailable MusicPlayer component");
		}
	}
}