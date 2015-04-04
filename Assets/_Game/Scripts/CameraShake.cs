using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	[SerializeField]
	private float _amount = 1.0f;

	[SerializeField]
	private float _ease = 0.2f;

	[SerializeField]
	private float _pauseDelay = 1.0f;

	private Vector3 _initialPos;
	private bool _isShaking = false;
	private float _initialAmount;

	private FollowPlayer _followPlayer;


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
		_initialPos = transform.position;
		_initialAmount = _amount;
		_followPlayer = gameObject.GetComponent<FollowPlayer>();
	}
	
	/// <summary>
	/// Update.
	/// </summary>
	void Update () {
		if( _isShaking ) {
			Vector3 offset = ( _initialPos + Random.insideUnitSphere ) * _amount;
			offset.x += _initialPos.x;
			offset.y += _initialPos.y;
			offset.z = transform.position.z;

			transform.position = offset;

			_amount -= Time.deltaTime * _ease;

			if( _amount <= 0.0f ) {
				_isShaking = false;
				_amount = _initialAmount;
			}
		}
	}

	//===================================================
	// PUBLIC METHODS
	//===================================================

	/// <summary>
	/// Shakes this instance.
	/// </summary>
	public void Shake() {
		_followPlayer.TogglePause( true );
		_isShaking = true;
		Invoke( "Resume", _pauseDelay );
	}

	//===================================================
	// PRIVATE METHODS
	//===================================================

	private void Resume() {
		_followPlayer.TogglePause( false );
	}

	//===================================================
	// EVENTS METHODS
	//===================================================



}
