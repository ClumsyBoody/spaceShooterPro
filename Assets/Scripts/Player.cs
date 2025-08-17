using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _baseSpeed = 10.5f;
    [SerializeField]
    private float _boostedSpeed = 15.5f;
    private float _currentSpeed;

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _SpeedBoostPrefab;

    [SerializeField]
    private GameObject _shieldVFX;

    [SerializeField]
    private GameObject _rightFire; // Reference to Right_Fire object
    [SerializeField]
    private GameObject _leftFire;  // Reference to Left_Fire object


    [SerializeField]
    private float _fireRate = 0.12f;
    private float _canFire = -1f;

    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;

    [SerializeField]
    private bool _isTripleShotActive = false;
    [SerializeField]
    private bool _isSpeedBoostActive = false;
    [SerializeField]
    private bool _isShieldActive = false;

    [SerializeField]
    private int _score;

    [SerializeField]
    private AudioSource _audioSource;
    
    [SerializeField]
    private AudioClip _playerExplosionSFX;
    [SerializeField]
    private AudioClip _powerupSFX;



    private UIManager _uiManager;

    //Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_spawnManager == null)
        {
            Debug.LogError("spawn manager is NULL!");
        }
        _currentSpeed = _baseSpeed;

        if (_shieldVFX != null)
        {
            _shieldVFX.SetActive(false);
        }

        if (_uiManager == null)
        {
            Debug.LogError("UI manager is NULL!");
        }
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("One or more AudioSource components are missing on the Player!");
            }
        }

    //Update is called once per frame
    void Update()
    {
        CalculateMovment();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
           FireLaser();
        }

        void CalculateMovment()
        {
            float horizontaInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(horizontaInput, verticalInput, 0) * _currentSpeed * Time.deltaTime);

            if (transform.position.y >= 0)
            {
                transform.position = new Vector3(transform.position.x, 0, 0);
            }
            else if (transform.position.y <= -3.8f)
            {
                transform.position = new Vector3(transform.position.x, -3.8f, 0);
            }
            /*a more optimized way for doing this is to use Mathf.Clamp method as follows
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);*/

            if (transform.position.x >= 11.38423f)
            {
                transform.position = new Vector3(-11.38423f, transform.position.y, 0);
            }
            else if (transform.position.x <= -11.38423f)
            {
                transform.position = new Vector3(11.38423f, transform.position.y, 0);
            }
        }
    }

    public void FireLaser()
    {
        _canFire = Time.time + _fireRate;
       
        if (_isTripleShotActive == true)
        {
            Instantiate(_tripleShotPrefab, transform.position + new Vector3(-2.753319f, 0.7469889f, 0.04504279f), Quaternion.identity);
        }
        else {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
        }

        // Play the laser sound effect
        if (_audioSource != null)
        {
            _audioSource.Play();
        }
}
    public void Shield() {
    
    
    }

    public void Damage() {
        //_lives -= 1;      all are the same thing
        //_lives = _lives - 1;

        // if shield is active 
        //deactivate shield
        //return;
        if (_isShieldActive)
        {
            _isShieldActive = false;

            if (_shieldVFX != null)
            {
                _shieldVFX.SetActive(false);
            }
            //disable shieldVFXActive
            return;
           
        }
  
        _lives--;
        if (_lives == 2)
        {
            _leftFire.SetActive(true);
        }
        else if (_lives == 1)
        {
            _rightFire.SetActive(true);
        }

        _uiManager.UpdateLives(_lives);

        if (_lives  < 1)
        {
            if (_audioSource != null && _playerExplosionSFX != null)
            {
                _audioSource.PlayOneShot(_playerExplosionSFX);
            }
            _spawnManager.onPlayerDeath();
            Destroy(this.gameObject);
        }
        
    }
            public void ActivateTripleShot()
    {
        _isTripleShotActive = true;
        if (_audioSource != null && _powerupSFX != null)
        {
            _audioSource.PlayOneShot(_powerupSFX);
        }
        StartCoroutine(DeactivateTripleShot());
    }

    IEnumerator DeactivateTripleShot()
    {
        yield return new WaitForSeconds(5f);
        _isTripleShotActive = false;
    }

    public void ActivateSpeedBoost()
    {
        if (!_isSpeedBoostActive)
        {
            _isSpeedBoostActive = true;
            if (_audioSource != null && _powerupSFX != null)
            {
                _audioSource.PlayOneShot(_powerupSFX);
            }
            _currentSpeed = _boostedSpeed; 
            StartCoroutine(DeactivateSpeedBoost());
        }
    }
    IEnumerator DeactivateSpeedBoost() {
        yield return new WaitForSeconds(5f);
        _isSpeedBoostActive = false;
        _currentSpeed = _baseSpeed;
       
    }

    public void ActivateShield()
    {
        _isShieldActive = true;
        if (_audioSource != null && _powerupSFX != null)
        {
            _audioSource.PlayOneShot(_powerupSFX);
        }
        if (_shieldVFX != null)
        {
            _shieldVFX.SetActive(true);
        }

    }
    //score method that adds 10 to score
    public void AddScore(int points) {
        _score += points;
        _uiManager.UpdateScore(_score);
    }

    }

