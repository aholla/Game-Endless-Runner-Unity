using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {
	
	[SerializeField]
	private Text _pickupText;

	[SerializeField]
	private Text _healthText;

	[SerializeField]
	private Text _distanceText;

	//===================================================
	// UNITY METHODS
	//===================================================

	public void UpdateUI( PlayerData _playerData ) {
		_pickupText.text = "" + _playerData.coins;
		_healthText.text = "" + _playerData.health;
		_distanceText.text = "" + _playerData.distance;
	}

	//===================================================
	// PUBLIC METHODS
	//===================================================

	public void UpdatePickups( int count ) {
		_pickupText.text = "" + count;
		//TODO: animate text.
	}

	public void UpdateHealth( int count ) {
		_healthText.text = "" + count;
		//TODO: animate text.
	}

	public void UpdateDistance( int count ) {
		_distanceText.text = "" + count;
		//TODO: animate text.
	}

	//===================================================
	// PRIVATE METHODS
	//===================================================



	//===================================================
	// EVENTS METHODS
	//===================================================




	
}
