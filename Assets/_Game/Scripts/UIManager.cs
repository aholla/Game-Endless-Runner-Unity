using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	public delegate void DelagatePlayGame();
	public event DelagatePlayGame eventPlayGame;
	public event DelagatePlayGame eventResetGame;

	[SerializeField]
	private RectTransform _titleScreen;

	[SerializeField]
	private RectTransform _gameOverScreen;

	[SerializeField]
	private RectTransform _fadeToBlackImage;

	[SerializeField]
	private Text _pickupText;

	[SerializeField]
	private Text _healthText;

	[SerializeField]
	private Text _distanceText;

	[SerializeField]
	private float _fadeDuration = 0.5f;

	private RectTransform _currentScreen;
	private GameOverScreen _gameoverScores; 

	//===================================================
	// UNITY METHODS
	//===================================================

	void Start() {
		_gameoverScores = _gameOverScreen.gameObject.GetComponent<GameOverScreen>();
	}
	
	//===================================================
	// PUBLIC METHODS
	//===================================================

	/// <summary>
	/// Called when the player hits the play button.
	/// </summary>
	public void OnPlay() {
		_fadeToBlackImage.gameObject.SetActive( true );

		LeanTween.alpha( _fadeToBlackImage, 1.0f, _fadeDuration ).setEase( LeanTweenType.easeOutSine )
			.setOnComplete( () => {
				_currentScreen.gameObject.SetActive( false );

				if( eventPlayGame != null ) {
					eventPlayGame();
				}

				FadeOutBlack();
			}
		);
	}

	/// <summary>
	/// Shows the title screen.
	/// </summary>
	public void ShowTitleScreen() {
		_fadeToBlackImage.gameObject.SetActive( true );

		LeanTween.alpha( _fadeToBlackImage, 1.0f, 0.01f );

		_titleScreen.gameObject.SetActive( true );
		_gameOverScreen.gameObject.SetActive( false );

		_currentScreen = _titleScreen;
		FadeOutBlack();
	}

	/// <summary>
	/// Shows the game over screen.
	/// </summary>
	public void ShowGameOverScreen( int coins, int distance ) {
		_gameoverScores.SetScores( coins, distance );

		_fadeToBlackImage.gameObject.SetActive( true );
		LeanTween.alpha( _fadeToBlackImage, 0.0f, 0.01f );
		LeanTween.alpha( _fadeToBlackImage, 1.0f, 0.6f ).setEase( LeanTweenType.easeOutSine )
			.setOnComplete( () => {
				_gameOverScreen.gameObject.SetActive( true );
				if( eventResetGame != null ) {
					eventResetGame();
				}
				FadeOutBlack();
			}
		);
		_currentScreen = _gameOverScreen;
	}

	/// <summary>
	/// Updates the UI.
	/// </summary>
	/// <param name="_playerData">The _player data.</param>
	public void UpdateHUD( PlayerData _playerData ) {
		UpdateHUDPickups( _playerData.coins );
		UpdateHUDHealth( _playerData.health );
		UpdateHUDDistance( _playerData.distance );
	}

	/// <summary>
	/// Updates the hud pickups.
	/// </summary>
	/// <param name="count">The count.</param>
	public void UpdateHUDPickups( int count ) {
		_pickupText.text = "" + count;
	}

	/// <summary>
	/// Updates the hud health.
	/// </summary>
	/// <param name="count">The count.</param>
	public void UpdateHUDHealth( int count ) {
		_healthText.text = "" + count;
	}

	/// <summary>
	/// Updates the hud distance.
	/// </summary>
	/// <param name="count">The count.</param>
	public void UpdateHUDDistance( int count ) {
		_distanceText.text = "" + count;
	}

	//===================================================
	// PRIVATE METHODS
	//===================================================

	/// <summary>
	/// Fades the out blackoout.
	/// </summary>
	private void FadeOutBlack() {
		LeanTween.alpha( _fadeToBlackImage, 0.0f, _fadeDuration ).setEase( LeanTweenType.easeOutSine )
			.setOnComplete( () => {
				_fadeToBlackImage.gameObject.SetActive( false );
			}
		);
	}
	

	//===================================================
	// EVENTS METHODS
	//===================================================





}
