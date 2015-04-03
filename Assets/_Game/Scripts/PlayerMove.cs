using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	[SerializeField]
	private float _acceleration;

	[SerializeField]
	private float _maxSpeed;

	private float _speed;
	private bool _isRunning;	
	
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
		_speed = 0.0f;
	}
	
	/// <summary>
	/// Update.
	/// </summary>
	void Update () {
		if( _isRunning ) {
			_speed += _acceleration;
			if( _speed > _maxSpeed ) {
				_speed = _maxSpeed;
			}
			transform.Translate( new Vector3( 0, 0, _speed ) );
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
