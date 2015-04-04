using UnityEngine;
using System.Collections;

public class PlayerBloodEmitter : MonoBehaviour {

	[SerializeField]
	private GameObject _bloodParticlesPrefab;
	private GameObject _bloodParticles;

	[SerializeField]
	private float _destroyDelay = 1.0f;

	//===================================================
	// UNITY METHODS
	//===================================================


	//===================================================
	// PUBLIC METHODS
	//===================================================

	/// <summary>
	/// Emits this instance.
	/// </summary>
	public void Emit( GameObject other ) {
		_bloodParticles = Instantiate( _bloodParticlesPrefab, Vector3.zero, Quaternion.identity  ) as GameObject;
		_bloodParticles.transform.SetParent( other.transform, false );

		Destroy( _bloodParticles, _destroyDelay );
	}

	//===================================================
	// PRIVATE METHODS
	//===================================================

	//===================================================
	// EVENTS METHODS
	//===================================================



}
