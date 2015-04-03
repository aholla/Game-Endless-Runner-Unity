using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	[SerializeField]
	private Transform _target;

	[SerializeField]
	private float _ease;

	private Vector3 _startPosition;
	private Vector3 _offset;

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
		_startPosition = transform.position;
		_offset = _target.position - transform.position;
	}
	
	/// <summary>
	/// Update.
	/// </summary>
	void Update () {
		transform.position = new Vector3( _startPosition.x, _startPosition.y, _target.position.z - _offset.z );
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
