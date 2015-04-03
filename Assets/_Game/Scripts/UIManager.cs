using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {
	
	[SerializeField]
	private Text _pickupText;

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
		UpdatePickups( 0 );
	}
	
	/// <summary>
	/// Update.
	/// </summary>
	void Update () {
		
	}

	//===================================================
	// PUBLIC METHODS
	//===================================================

	public void UpdatePickups( int count ) {
		_pickupText.text = "" + count;
		//TODO: animate text.
	}

	//===================================================
	// PRIVATE METHODS
	//===================================================



	//===================================================
	// EVENTS METHODS
	//===================================================



}
