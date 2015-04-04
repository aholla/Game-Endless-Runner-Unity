using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupSpawner : MonoBehaviour {

	[SerializeField]
	private CameraController _cameraContoller;

	[SerializeField]
	private Transform _locationLeft;

	[SerializeField]
	private Transform _locationRight;

	[SerializeField]
	private Transform _locationCenter;

	[SerializeField]
	private float _interval = 1;

	private ObjectPool _pool;
	private List<Pickup> _pickups;
	private bool _canSpawn;
	
	//===================================================
	// UNITY METHODS
	//===================================================

	/// <summary>
	/// Awake.
	/// </summary>
	void Awake () {
		_pool = GetComponent<ObjectPool>();
		_pickups = new List<Pickup>();
	}

	/// <summary>
	/// Start.
	/// </summary>
	void Start () {
		_pool.Init();		
	}
	
	/// <summary>
	/// Update.
	/// </summary>
	void Update () {
		CullPickups();
	}

	//===================================================
	// PUBLIC METHODS
	//===================================================

	/// <summary>
	/// Starts this running.
	/// </summary>
	public void StartRunning() {
		_canSpawn = true;
		StartCoroutine( SpawnPickups() );
	}

	/// <summary>
	/// Resets this instance.
	/// </summary>
	public void Reset() {
		_canSpawn = false;
		for( int i = _pickups.Count - 1; i >= 0; i -= 1 ) {
			Pickup pickup = _pickups[ i ];
			GameObject pickupGO = pickup.gameObject;
			pickupGO.SetActive( false );
			_pickups.Remove( pickup );
		}
	}

	//===================================================
	// PRIVATE METHODS
	//===================================================

	/// <summary>
	/// Spawns the pickups at an interval.
	/// </summary>
	/// <returns></returns>
	private IEnumerator SpawnPickups() {
		while( _canSpawn ) {
			Spawn();
			yield return new WaitForSeconds( _interval );
		}
	}

	/// <summary>
	/// Spawns the pickup.
	/// </summary>
	/// <returns></returns>
	private Pickup Spawn() {

		// select a position.
		Vector3 pos = new Vector3();
		int random = Random.Range( 0, 3 );
		switch( random ) {
			case 0:
				pos.x = _locationLeft.position.x;
				pos.y = _locationLeft.position.y;
				break;
			case 1:
				pos.x = _locationRight.position.x;
				pos.y = _locationRight.position.y;
				break;
			case 2:
				pos.x = _locationCenter.position.x;
				pos.y = _locationCenter.position.y;
				break;
		}
		pos.z = _cameraContoller.Far + 10.0f;

		// get a pickup and set position.
		GameObject pickupGO = _pool.GetGameObject();
		pickupGO.transform.position = pos;

		Pickup pickup = pickupGO.GetComponent<Pickup>();
		_pickups.Add( pickup );
		return pickup;
	}

	/// <summary>
	/// Culls the pickups when offscreen.
	/// </summary>
	private void CullPickups() {
		for( int i = _pickups.Count - 1; i >= 0; i -= 1 ) {
			Pickup pickup = _pickups[ i ];
			GameObject pickupGO = pickup.gameObject;
			if( pickupGO.transform.position.z + 5.0f < _cameraContoller.PosZ ) {
				pickupGO.SetActive( false );
				_pickups.Remove( pickup );
			}
		}
	}

	//===================================================
	// EVENTS METHODS
	//===================================================



}
