using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	[SerializeField]
	private AudioClip _menuMusic;

	[SerializeField]
	private AudioClip _gameMusic;

	private AudioSource _source;	

	//===================================================
	// UNITY METHODS
	//===================================================

	/// <summary>
	/// Start.
	/// </summary>
	void Start () {
		_source = gameObject.AddComponent<AudioSource>();
	}

	//===================================================
	// PUBLIC METHODS
	//===================================================

	/// <summary>
	/// Plays the music.
	/// </summary>
	/// <param name="musicType">Type of the music.</param>
	public void PlayMusic( Enums.MusicType musicType ) {
		switch( musicType ) {
			case Enums.MusicType.Menu:
				_source.clip = _menuMusic;
				break;
			case Enums.MusicType.Game:
				_source.clip = _gameMusic;
				break;
		}
		_source.loop = true;
		_source.Play();
	}

	//===================================================
	// PRIVATE METHODS
	//===================================================



	//===================================================
	// EVENTS METHODS
	//===================================================



}
