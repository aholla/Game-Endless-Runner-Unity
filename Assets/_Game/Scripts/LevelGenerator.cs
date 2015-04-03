using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	[SerializeField]
	private CameraController _cameraContoller;

	private ObjectPool _pool;
	private List<LevelChunk> _levelChunks;

	private float _currentPosZ;
	
	//===================================================
	// UNITY METHODS
	//===================================================

	/// <summary>
	/// Awake.
	/// </summary>
	void Awake () {
		_pool = GetComponent<ObjectPool>();
		_currentPosZ = 0.0f;
		_levelChunks = new List<LevelChunk>();
	}

	/// <summary>
	/// Start.
	/// </summary>
	void Start () {
		_pool.Init();

		// create initial chunks.
		CreateFirstSetOfChunks();
	}
	
	/// <summary>
	/// Update.
	/// </summary>
	void Update () {

		// if camera position is greater than the current level size, spawn a new level chunk.
		if( _currentPosZ <= _cameraContoller.Far ) {
			SpawnLevelChunk();
		}

		// remove the old chunks.
		CullOldChunks();
	}
	

	//===================================================
	// PUBLIC METHODS
	//===================================================



	//===================================================
	// PRIVATE METHODS
	//===================================================
	
	/// <summary>
	/// Creates the first set of chunks.
	/// </summary>
	private void CreateFirstSetOfChunks() {
		// while within range of the camera, add more level pieces.
		for( int i = 0; i < 1; i++ ) {
			//SpawnLevelChunk();
		}

		while( _currentPosZ < _cameraContoller.Far ) {
			SpawnLevelChunk();
		}
	}

	/// <summary>
	/// Spawns the level chunk from the object pool
	/// </summary>
	private void SpawnLevelChunk() {
		// get gameobject from pool.
		GameObject levelGO = _pool.GetGameObject();
		levelGO.transform.position = new Vector3( transform.position.x, transform.position.y, _currentPosZ );
		
		// increment the z position.
		LevelChunk chunk = levelGO.GetComponent<LevelChunk>();
		chunk.Init();
		_currentPosZ += chunk.Size;

		_levelChunks.Add( chunk );
	}

	/// <summary>
	/// Culls the old chunks when they are behind the camera.
	/// </summary>
	private void CullOldChunks() {
		for( int i = _levelChunks.Count-1; i >=0; i-= 1 ) {
			LevelChunk chunk = _levelChunks[ i ];

			if( chunk.FarEdge < _cameraContoller.PosZ ) {
				chunk.gameObject.SetActive( false );
				_levelChunks.Remove( chunk );
			}
		}
	}

	//===================================================
	// EVENTS METHODS
	//===================================================



}
