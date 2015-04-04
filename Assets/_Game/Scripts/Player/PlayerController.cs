using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float _rotationIncrement;

	[SerializeField]
	private float _rotationMax;

	[SerializeField]
	private float _rotateSpeed;

	[SerializeField]
	private float _rotateReturnSpeed;	

	private Quaternion _initialRotation;
	private float _rotation = 0;
	private bool _left = false;
	private bool _right = false;
	private  bool _isRunning;

	//===================================================
	// UNITY METHODS
	//===================================================

	/// <summary>
	/// Awake.
	/// </summary> 
	void Awake() {
	}

	/// <summary>
	/// Start.
	/// </summary>
	void Start() {
		// save the initial rotation.
		_initialRotation = transform.rotation;
	}

	/// <summary>
	/// Update.
	/// </summary>
	void Update() {
		if( _isRunning ) {
			// check for input.
			CheckInput();

			// if left add negative rotation.
			if( _left ) {
				UpdateRotation( -_rotationIncrement );
			}

			// if right add positive rotation.
			if( _right ) {
				UpdateRotation( _rotationIncrement );
			}

			// set the initial and dest rotations.
			Quaternion startRotation = transform.rotation;
			Quaternion endRotation = _initialRotation * Quaternion.Euler( new Vector3( 0.0f, 0.0f, transform.rotation.z + _rotation ) );

			// Slerp to the dest rotation if it is different.
			if( startRotation != endRotation ) {
				transform.rotation = Quaternion.Slerp( startRotation, endRotation, Time.deltaTime * _rotateSpeed );
			}
		}
		//TODO: Think about gravity, show the player be forced back to the center.
	}

	//===================================================
	// PUBLIC METHODS
	//===================================================

	/// <summary>
	/// ENables the controls..
	/// </summary>
	public void StartRunning() {
		_rotation = 0;
		_left = false;
		_right = false;
		_isRunning = true;
	}

	/// <summary>
	/// Disables the controls
	/// </summary>
	public void StopRunning() {
		_isRunning = false;
	}

	//===================================================
	// PRIVATE METHODS
	//===================================================

	/// <summary>
	/// Checks the input.
	/// </summary>
	private void CheckInput() {
		// check for keys down.
		if( Input.GetKeyDown( KeyCode.LeftArrow ) ) {
			_left = true;
		}
		if( Input.GetKeyDown( KeyCode.RightArrow ) ) {
			_right = true;
		}

		// check for keys up.
		if( Input.GetKeyUp( KeyCode.LeftArrow ) ) {
			_left = false;
		}
		if( Input.GetKeyUp( KeyCode.RightArrow ) ) {
			_right = false;
		}

		// TODO: Implement mouse countrols.
	}

	/// <summary>
	/// Updates the rotation and caps it.
	/// </summary>
	/// <param name="rotationAmount">The rotation amount.</param>
	private void UpdateRotation( float rotationAmount ) {
		_rotation += rotationAmount;
		if( _rotation >= _rotationMax ) {
			_rotation = _rotationMax;
		} else if( _rotation <= -_rotationMax ) {
			_rotation = -_rotationMax;
		}
	}


	//===================================================
	// EVENTS METHODS
	//===================================================
}
