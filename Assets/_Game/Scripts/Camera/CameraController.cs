using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	/// <summary>
	/// Far - used to spawn objects in the distance/
	/// </summary>
	private float _far;
	public float Far {
		get {
			return _far;
		}
		private set {
			_far = value;
		}
	}

	/// <summary>
	/// pozZ - used to cull objects behind the camera.
	/// </summary>
	private float _posZ;
	public float PosZ {
		get {
			return _posZ;
		}
		private set {
			_posZ = value;
		}
	}

	[SerializeField]
	private float _distancePadding;

	private Camera _camera;
	private  Vector3 _initialPosition;
	private bool _isRunning;
	
	//===================================================
	// UNITY METHODS
	//===================================================

	/// <summary>
	/// Awake.
	/// </summary>
	void Awake () {
		_camera = GetComponent<Camera>();
		_initialPosition = transform.position;
	}
		
	/// <summary>
	/// Update.
	/// </summary>
	void Update () {
		if( _isRunning ) {
			_far = ( transform.position.z + _camera.farClipPlane ) + _distancePadding;
			_posZ = transform.position.z;
		}
	}

	//===================================================
	// PUBLIC METHODS
	//===================================================

	/// <summary>
	/// Start.
	/// </summary>
	public void StartRunning() {
		_isRunning = true;
	}

	/// <summary>
	/// Resets this instance.
	/// </summary>
	public void Reset() {
		_isRunning = false;
		transform.position = _initialPosition;
		_far = ( transform.position.z + _camera.farClipPlane ) + _distancePadding;
		_posZ = transform.position.z;
	}

	//===================================================
	// PRIVATE METHODS
	//===================================================



	//===================================================
	// EVENTS METHODS
	//===================================================




	
}
