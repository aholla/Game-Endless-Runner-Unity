using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	public delegate void DelegateCollision( int value );
	public event DelegateCollision eventPickupCollision;
	public event DelegateCollision eventObstacleCollision;

	// This shoudl go on the blade really but there will only be one blade so one value is okay.
	[SerializeField]
	private int _playerDamage;
	
	//===================================================
	// UNITY METHODS
	//===================================================

	/// <summary>
	/// Called when [trigger enter].
	/// </summary>
	/// <param name="other">The other.</param>
	void OnTriggerEnter( Collider other ) {

		// if the collision is with a pickup. Dispatch the points.
		if( other.gameObject.tag == Enums.CollisionType.Pickup.ToString() ) {
			Pickup pickup = other.gameObject.GetComponent<Pickup>();
			int points = pickup.points;

			if( eventPickupCollision != null ) {
				eventPickupCollision( points );
			}

			other.gameObject.SetActive( false );

			AddParticles( Enums.CollisionType.Pickup );
			//TODO: play sound.

		} else if( other.gameObject.tag == Enums.CollisionType.Obstacle.ToString() ) {
			if( eventObstacleCollision != null ) {
				eventObstacleCollision( _playerDamage );
			}

			AddParticles( Enums.CollisionType.Obstacle );
		}
	}

	//===================================================
	// PUBLIC METHODS
	//===================================================



	//===================================================
	// PRIVATE METHODS
	//===================================================

	// TODO: Fire particles.
	private void AddParticles( Enums.CollisionType type ) {
		switch( type ) {
			case Enums.CollisionType.Pickup:
				// Gold particles
				break;
			case Enums.CollisionType.Obstacle:
				// Red particles
				break;
		}
	}

	//===================================================
	// EVENTS METHODS
	//===================================================



}
