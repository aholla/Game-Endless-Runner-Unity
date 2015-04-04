using UnityEngine;
using System.Collections;

public class LevelChunk : MonoBehaviour {

	/// <summary>
	/// The size of the chunk. Used for spawning.
	/// </summary>
	private float _size = 0.0f;
	public float Size {
		get {
			return _size;
		}
		private set{
			_size = value;
		}
	}


	/// <summary>
	/// The far edge of the chunk. Used for culling.
	/// </summary>
	private float _farEdge;
	public float FarEdge {
		get {
			return _farEdge;
		}
		private set {
			_farEdge = value;
		}
	}

	private Collider _collider;

	//===================================================
	// UNITY METHODS
	//===================================================

	/// <summary>
	/// Awake. Sets tehe size of the chunk based upons the bounds Z.
	/// </summary>
	void Awake () {
		GameObject floor = transform.Find( "Floor" ).gameObject;
		Renderer renderer = floor.GetComponent<Renderer>();
		_size = renderer.bounds.extents.z * 2.0f; // centered object.

		// make sure the collider is enabled, it gets turned off on player collision.
		_collider = gameObject.GetComponentInChildren<Collider>();
		_collider.enabled = true;
	}

	/// <summary>
	/// Called when [enable].
	/// </summary>
	void OnEnable() {
		_collider.enabled = true;
	}
	
	//===================================================
	// PUBLIC METHODS
	//===================================================

	/// <summary>
	/// Sets the far edge of the chunk based upon the transform and the bounds.
	/// </summary>
	public void Init() {
		_farEdge = _size + gameObject.transform.position.z;
	}

	//===================================================
	// PRIVATE METHODS
	//===================================================



	//===================================================
	// EVENTS METHODS
	//===================================================



}
