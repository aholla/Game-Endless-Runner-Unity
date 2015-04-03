using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	[SerializeField]
	private PlayerCollision _playerCollision;

	[SerializeField]
	private UIManager _uiManager;

	private int _pickupCount;
	
	//===================================================
	// UNITY METHODS
	//===================================================

	/// <summary>
	/// Awake.
	/// </summary>
	void Awake () {
		_pickupCount = 0;
	}

	/// <summary>
	/// Start.
	/// </summary>
	void Start () {
		_playerCollision.eventPickupCollision += OnPlayerPickup;
	}	
	
	/// <summary>
	/// Update.
	/// </summary>
	void Update () {
		
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

	/// <summary>
	/// Called when Player collides with Pickup.
	/// </summary>
	/// <param name="value">The value.</param>
	private void OnPlayerPickup( int value ) {
		_pickupCount += value;
		_uiManager.UpdatePickups( _pickupCount );
	}

}
