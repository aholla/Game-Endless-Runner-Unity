using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	[SerializeField]
	private PlayerCollision _playerCollision;

	[SerializeField]
	private UIManager _uiManager;

	[SerializeField]
	private PlayerData _playerData;

	[SerializeField]
	private CameraShake _cameraShake;
	
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
		_playerCollision.eventPickupCollision += OnPlayerPickup;
		_playerCollision.eventObstacleCollision += OnPlayerCollision;

		_uiManager.UpdateHealth( _playerData.health );
		_uiManager.UpdatePickups( _playerData.coins );
		_uiManager.UpdateDistance( _playerData.distance );
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
		_playerData.coins += value;
		_uiManager.UpdatePickups( _playerData.coins );
	}

	private void OnPlayerCollision( int value ) {
		_playerData.health -= value;
		_uiManager.UpdateHealth( _playerData.health );

		if( _playerData.health <= 0 ) {
			// DEAD
			//TODO: End game
		}

		_cameraShake.Shake();

	}

}
