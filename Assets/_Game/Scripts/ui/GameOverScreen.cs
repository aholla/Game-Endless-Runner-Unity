using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

	[SerializeField]
	private Text _coins;

	[SerializeField]
	private Text _distance;
	
	//===================================================
	// UNITY METHODS
	//===================================================


	//===================================================
	// PUBLIC METHODS
	//===================================================

	/// <summary>
	/// Sets the scores.
	/// </summary>
	/// <param name="coins">The coins.</param>
	/// <param name="distance">The distance.</param>
	public void SetScores( int coins, int distance ) {
		_coins.text = coins.ToString();
		_distance.text = distance.ToString();
	}

	//===================================================
	// PRIVATE METHODS
	//===================================================



	//===================================================
	// EVENTS METHODS
	//===================================================



}
