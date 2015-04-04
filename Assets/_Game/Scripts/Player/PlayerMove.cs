using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	[SerializeField]
	private float _acceleration;

	[SerializeField]
	private float _maxSpeed;

	[SerializeField]
	private float _imapactDistance;

	private float _velocity;
	private bool _isRunning;
	private PlayerCollision _playerCollison;
	private Vector3 _initialPosition;
	
	//===================================================
	// UNITY METHODS
	//===================================================

	/// <summary>
	/// Awake.
	/// </summary>
	void Awake () {
		_initialPosition = transform.position;
	}

	/// <summary>
	/// Start.
	/// </summary>
	void Start () {
		_isRunning = false;
		_velocity = 0.0f;
		_playerCollison = GetComponent<PlayerCollision>();
		_playerCollison.eventObstacleCollision += OnCollision;
	}	
	
	/// <summary>
	/// Update.
	/// </summary>
	void Update () {
		if( _isRunning ) {
			_velocity += _acceleration;
			if( _velocity > _maxSpeed ) {
				_velocity = _maxSpeed;
			}
			transform.Translate( new Vector3( 0, 0, _velocity ) * Time.deltaTime );
			//TODO: at some point the transform will have to be set back to 0 to stop massive numbers.
		}
	}

	//===================================================
	// PUBLIC METHODS
	//===================================================

	/// <summary>
	/// Starts the running.
	/// </summary>
	public void StartRunning() {
		Vector3 pos = new Vector3( transform.position.x, transform.position.y, 0.0f );
		transform.position = pos;
		_velocity = 0.0f;
		_isRunning = true;
	}

	/// <summary>
	/// Stops the player running.
	/// </summary>
	public void StopRunning() {
		_isRunning = false;
	}

	/// <summary>
	/// Resets this instance.
	/// </summary>
	public void Reset() {
		transform.position = _initialPosition;
		transform.rotation = Quaternion.identity;
	}

	//===================================================
	// PRIVATE METHODS
	//===================================================



	//===================================================
	// EVENTS METHODS
	//===================================================

	/// <summary>
	/// Called when COllision happens.
	/// </summary>
	private void OnCollision( int value ) {
		_velocity = -_imapactDistance;
	}

}
