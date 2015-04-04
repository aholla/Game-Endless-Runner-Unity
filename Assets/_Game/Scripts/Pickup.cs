using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public int points = 10;

	[SerializeField]
	private GameObject _particlePrefab;

	[SerializeField]
	private GameObject _view;

	private GameObject _particles;
	
	//===================================================
	// UNITY METHODS
	//===================================================

	void OnEnable() {
		// make sure the view is enabled.
		_view.SetActive( true );
	}

	//===================================================
	// PUBLIC METHODS
	//===================================================

	/// <summary>
	/// Called when a player collides with the pickup.
	/// </summary>
	public void Collided() {
		_view.SetActive( false );
		EmitPaticles();
		Invoke( "Destroy", 1.0f );
	}

	//===================================================
	// PRIVATE METHODS
	//===================================================

	/// <summary>
	/// Emits the paticles.
	/// </summary>
	private void EmitPaticles() {
		Vector3 pos = transform.position;
		pos.z -= 5.0f;

		_particles = Instantiate( _particlePrefab, pos, Quaternion.identity ) as GameObject;
		_particles.transform.SetParent( gameObject.transform );
	}

	/// <summary>
	/// Disables the pickup.
	/// </summary>
	private void Destroy() {
		Destroy( _particles );
		gameObject.SetActive( false );		
	}

	//===================================================
	// EVENTS METHODS
	//===================================================



}
