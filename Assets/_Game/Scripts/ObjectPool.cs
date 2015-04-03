using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

	[SerializeField]
	private GameObject _prefab;
	
	[SerializeField]
	private int _numOfObjects = 10;

	[SerializeField]
	private GameObject _optionalParent;

	private List<GameObject> _pool;

	//===================================================
	// PUBLIC METHODS
	//===================================================

	/// <summary>
	/// Initializes the pool with the specified number of GameObject derived from the prefab.
	/// </summary>
	public void Init() {
		_pool = new List<GameObject>( _numOfObjects );
		for( int i = 0; i < _numOfObjects; i++ ) {
			AddGameObject();
		}
	}

	/// <summary>
	/// Gets a GameObject from the pool or creates a new one if it is full/empty.
	/// </summary>
	/// <returns></returns>
	public GameObject GetGameObject() {
		for( int i = 0; i < _pool.Count; i++ ) {
			GameObject ob = _pool[ i ];
			if( !ob.activeSelf ) {
				ob.SetActive( true );
				return ob;
			}
		}
		// if here, then there is not enought to spawn so add another one.
		return AddGameObject();
	}

	/// <summary>
	/// Releases the object back to the pool but it is so simple it is not really needed.
	/// </summary>
	/// <param name="go">The go.</param>
	public void ReleaseObject( GameObject go ) {
		go.SetActive( false );
	}	

	/// <summary>
	/// Releases all the gameObjects - disables them.
	/// </summary>
	public void ReleaseAll() {
		for( int i = 0; i < _pool.Count; i++ ) {
			GameObject ob = _pool[ i ];
			ob.SetActive( false );
		}
	}

	//===================================================
	// PRIVATE METHODS
	//===================================================

	/// <summary>
	/// Adds a GameObject to pool.
	/// </summary>
	/// <returns></returns>
	private GameObject AddGameObject() {
		GameObject go = Instantiate( _prefab, Vector3.zero, Quaternion.identity ) as GameObject;
		if( _optionalParent == null ) {
			go.transform.SetParent( this.transform );
		} else {
			go.transform.SetParent( _optionalParent.transform );
		}
		go.SetActive( false );
		_pool.Add( go );
		return go;
	}
}
