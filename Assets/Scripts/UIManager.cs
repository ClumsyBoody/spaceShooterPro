using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Handle to text
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Image _livesImg;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Text _gameOverText;
    private bool _isGameOver;
    [SerializeField]
    private Text _RKeyText;

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _gameOverText.gameObject.SetActive(false);
        _RKeyText.gameObject.SetActive(false);
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("GameManager is null");
        }
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
    }

    public void UpdateLives(int currentLives)
    {
        // Display img sprite
        // Give it a new one depending on the currentLives index
        _livesImg.sprite = _liveSprites[currentLives];

        if (currentLives == 0)
        {

            GameOverSequence();
        }
    }

    void GameOverSequence()
    {
        _gameManager.GameOver();
        _gameOverText.gameObject.SetActive(true);
        _RKeyText.gameObject.SetActive(true);
        StartCoroutine(GameOverTextFlicker()); // Start coroutine here
    }

    private IEnumerator GameOverTextFlicker()
    {
        while (true) // Keep flickering indefinitely
        {
            // Toggle the active state of both texts
            bool newState = !_gameOverText.gameObject.activeSelf; // Determine the new state
            _gameOverText.gameObject.SetActive(newState);
            _RKeyText.gameObject.SetActive(newState);

            yield return new WaitForSeconds(1); // Wait 1 second before toggling again
        }
    }
    private void RestartLevel()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
