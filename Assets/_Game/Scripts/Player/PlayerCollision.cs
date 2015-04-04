using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	public delegate void DelegateCollision( int value );
	public event DelegateCollision eventPickupCollision;
	public event DelegateCollision eventObstacleCollision;

	// This shoudl go on the blade really but there will only be one blade so one value is okay.
	[SerializeField]
	private int _playerDamage;

	[SerializeField]
	private AudioClip _soundPickup;

	[SerializeField]
	private AudioClip _soundCollision;

	private PlayerBloodEmitter _playerBloodEmitter;
	private  AudioSource _audioSource;

	//===================================================
	// UNITY METHODS
	//===================================================

	/// <summary>
	/// Start.
	/// </summary>
	void Start() {
		_audioSource = gameObject.GetComponent<AudioSource>();
		_playerBloodEmitter = GetComponent<PlayerBloodEmitter>();
	}

	/// <summary>
	/// Called when [trigger enter].
	/// </summary>
	/// <param name="other">The other.</param>
	void OnTriggerEnter( Collider other ) {

		// if the collision is with a pickup. Dispatch the points.
		if( other.gameObject.tag == Enums.CollisionType.Pickup.ToString() ) {
			PlaySound( Enums.CollisionType.Pickup ); 

			Pickup pickup = other.gameObject.GetComponent<Pickup>();
			pickup.Collided();
			int points = pickup.points;

			if( eventPickupCollision != null ) {
				eventPickupCollision( points );
			}
			//TODO: play sound.

		} else if( other.gameObject.tag == Enums.CollisionType.Obstacle.ToString() ) {
			PlaySound( Enums.CollisionType.Obstacle ); 

			if( eventObstacleCollision != null ) {
				eventObstacleCollision( _playerDamage );
			}

			// disable the other collider - looks funny but continues the game.
			other.enabled = false;

			_playerBloodEmitter.Emit( other.gameObject );

		}
	}
	//===================================================
	// PUBLIC METHODS
	//===================================================


	//===================================================
	// PRIVATE METHODS
	//===================================================

	/// <summary>
	/// Plays the sound.
	/// </summary>
	/// <param name="type">The type.</param>
	private void PlaySound( Enums.CollisionType type ) {
		switch( type ) {
			case Enums.CollisionType.Pickup:
				_audioSource.clip = _soundPickup;
				break;
			case Enums.CollisionType.Obstacle:
				_audioSource.clip = _soundCollision;
				break;
		}
		_audioSource.Play();
	}

	//===================================================
	// EVENTS METHODS
	//===================================================



}
