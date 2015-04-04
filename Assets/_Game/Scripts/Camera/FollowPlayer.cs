using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	[SerializeField]
	private Transform _target;

	[SerializeField]
	private float _ease;

	private Vector3 _startPosition;
	private Vector3 _offset;
	private bool _paused;

	//===================================================
	// UNITY METHODS
	//===================================================

	/// <summary>
	/// Start.
	/// </summary>
	void Start () {
		_startPosition = transform.position;
		_offset = _target.position - transform.position;
	}
	
	/// <summary>
	/// Update.
	/// </summary>
	void Update () {
		if( !_paused ) {
			Vector3 targetPos = new Vector3( _startPosition.x, _startPosition.y, _target.position.z - _offset.z );
			transform.position = Vector3.Lerp( transform.position, targetPos, Time.deltaTime * _ease );
		}
	}

	//===================================================
	// PUBLIC METHODS
	//===================================================

	/// <summary>
	/// Toggles the pause.
	/// </summary>
	/// <param name="isTrue">if set to <c>true</c> [is true].</param>
	public void TogglePause( bool isTrue ) {
		_paused = isTrue;
	}

	//===================================================
	// PRIVATE METHODS
	//===================================================



	//===================================================
	// EVENTS METHODS
	//===================================================




	
}
