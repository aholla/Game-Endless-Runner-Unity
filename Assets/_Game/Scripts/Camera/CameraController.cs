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
	
	//===================================================
	// UNITY METHODS
	//===================================================

	/// <summary>
	/// Awake.
	/// </summary>
	void Awake () {
		_camera = GetComponent<Camera>();
	}

	/// <summary>
	/// Start.
	/// </summary>
	void Start () {
		
	}
	
	/// <summary>
	/// Update.
	/// </summary>
	void Update () {
		_far = ( transform.position.z + _camera.farClipPlane ) + _distancePadding;
		_posZ = transform.position.z;
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
