using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	public delegate void DelegateCollision( int value );
	public event DelegateCollision eventPickupCollision;
	
	//===================================================
	// UNITY METHODS
	//===================================================

	/// <summary>
	/// Awake.
	/// </summary>
	void Awake () {
	}

	/// <summary>
	/// Start.
	/// </summary>
	void Start () {
		
	}
	
	/// <summary>
	/// Update.
	/// </summary>
	void Update () {
		
	}


	/// <summary>
	/// Called when [trigger enter].
	/// </summary>
	/// <param name="other">The other.</param>
	void OnTriggerEnter( Collider other ) {
		// if the collision is with a pickup. Dispatch the points.
		if( other.gameObject.tag == "Pickup" ) {
			Pickup pickup = other.gameObject.GetComponent<Pickup>();
			int points = pickup.points;

			if( eventPickupCollision != null ) {
				eventPickupCollision( points );
			}

			other.gameObject.SetActive( false );
			// TODO: add PARTICLES!
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
