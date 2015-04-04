using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	public delegate void DelegateCollision( int value );
	public event DelegateCollision eventPickupCollision;
	public event DelegateCollision eventObstacleCollision;

	// This shoudl go on the blade really but there will only be one blade so one value is okay.
	[SerializeField]
	private int _playerDamage;

	private PlayerBloodEmitter _playerBloodEmitter;

	//===================================================
	// UNITY METHODS
	//===================================================

	/// <summary>
	/// Start.
	/// </summary>
	void Start() {
		_playerBloodEmitter = GetComponent<PlayerBloodEmitter>();
	}

	/// <summary>
	/// Called when [trigger enter].
	/// </summary>
	/// <param name="other">The other.</param>
	void OnTriggerEnter( Collider other ) {

		// if the collision is with a pickup. Dispatch the points.
		if( other.gameObject.tag == Enums.CollisionType.Pickup.ToString() ) {
			Pickup pickup = other.gameObject.GetComponent<Pickup>();
			pickup.Collided();
			int points = pickup.points;

			if( eventPickupCollision != null ) {
				eventPickupCollision( points );
			}
			//TODO: play sound.

		} else if( other.gameObject.tag == Enums.CollisionType.Obstacle.ToString() ) {
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


	//===================================================
	// EVENTS METHODS
	//===================================================



}
