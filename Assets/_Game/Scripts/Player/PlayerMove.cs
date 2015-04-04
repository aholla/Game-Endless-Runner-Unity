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
		_isRunning = true;
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
