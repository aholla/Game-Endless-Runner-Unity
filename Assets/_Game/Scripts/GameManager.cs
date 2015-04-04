using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	[SerializeField]
	private GameObject _player;

	[SerializeField]
	private UIManager _uiManager;

	[SerializeField]
	private LevelGenerator _levelGenerator;

	[SerializeField]
	private PickupSpawner _pickupSpawner;

	[SerializeField]
	private GameObject _camera;

	private CameraShake _cameraShake;
	private CameraController _cameraController;

	[SerializeField]
	private int _startingHealth = 0;

	private PlayerData _playerData;
	private PlayerMove _playerMove;
	private PlayerCollision _playerCollision;
	private PlayerController _playerContoller;

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
		_playerData = new PlayerData();
		
		_uiManager.eventPlayGame += StartRunning;
		_uiManager.eventResetGame += onResetGame;

		_playerMove = _player.GetComponent<PlayerMove>();
		_playerContoller = _player.GetComponent<PlayerController>();

		_playerCollision = _player.GetComponent<PlayerCollision>();
		_playerCollision.eventPickupCollision += OnPlayerPickup;
		_playerCollision.eventObstacleCollision += OnPlayerCollision;

		_cameraShake = _camera.GetComponent<CameraShake>();
		_cameraController = _camera.GetComponent<CameraController>();

		Reset();
		ShowTitleScreen();
	}

	/// <summary>
	/// Update. COllects the distance.
	/// </summary>
	void Update() {
		_playerData.distance = ( int ) Mathf.Round( _playerMove.gameObject.transform.position.z * 0.1f );
		_uiManager.UpdateHUDDistance( _playerData.distance );
	}

	//===================================================
	// PUBLIC METHODS
	//===================================================
	
	/// <summary>
	/// Shows the title screen.
	/// </summary>
	private void ShowTitleScreen() {
		_uiManager.ShowTitleScreen();
	}

	/// <summary>
	/// Shows the game over screen.
	/// </summary>
	private void ShowGameOverScreen() {
		_uiManager.ShowGameOverScreen( _playerData.coins, _playerData.distance );
	}
	

	//===================================================
	// PRIVATE METHODS
	//===================================================

	/// <summary>
	/// Resets this instance.
	/// </summary>
	private void Reset() {
		_playerData.health = _startingHealth;
		_playerData.coins = 0;
		_playerData.distance = 0;

		_uiManager.UpdateHUDHealth( _playerData.health );
		_uiManager.UpdateHUDPickups( _playerData.coins );
		_uiManager.UpdateHUDDistance( _playerData.distance );

		_playerMove.Reset();
		_cameraController.Reset();
		_levelGenerator.Reset();
		_pickupSpawner.Reset();
	}

	//===================================================
	// EVENTS METHODS
	//===================================================

	/// <summary>
	/// Starts the game running.
	/// </summary>
	private void StartRunning() {
		_cameraController.StartRunning();
		_levelGenerator.StartRunning();
		_pickupSpawner.StartRunning();
		_playerMove.StartRunning();
		_playerContoller.StartRunning();
	}

	private void StopRunning() {
		_playerMove.StopRunning();
		_playerContoller.StopRunning();
	}

	/// <summary>
	/// Stops the game running.
	/// </summary>
	private void onResetGame() {
		Reset();
	}

	/// <summary>
	/// Called when Player collides with Pickup.
	/// </summary>
	/// <param name="value">The value.</param>
	private void OnPlayerPickup( int value ) {
		_playerData.coins += value;
		_uiManager.UpdateHUDPickups( _playerData.coins );
	}

	private void OnPlayerCollision( int value ) {
		_playerData.health -= value;
		_uiManager.UpdateHUDHealth( _playerData.health );

		if( _playerData.health <= 0 ) {
			// DEAD
			StopRunning();
			ShowGameOverScreen();
		}

		_cameraShake.Shake();
	}

}
