using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;

    [SerializeField]
    private int _powerupID;

    [SerializeField] private AudioClip _powerupSFX;  // Assign in Inspector
    private AudioSource _audioSource;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();

        if (_audioSource == null)
        {
            Debug.LogError("AudioSource missing on PowerUp: " + gameObject.name);
        }
        if (_spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer missing on PowerUp: " + gameObject.name);
        }
        if (_collider == null)
        {
            Debug.LogError("Collider missing on PowerUp: " + gameObject.name);
        }
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if (transform.position.y < -6.5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player == null)
            {
                Debug.Log("Player is not here.");
                return;
            }

            switch (_powerupID)
            {
                case 0:
                    player.ActivateTripleShot();
                    break;
                case 1:
                    player.ActivateSpeedBoost();
                    break;
                case 2:
                    player.ActivateShield();
                    break;
                default:
                    Debug.LogWarning("Unknown Power-Up ID!");
                    break;
            }

            // Play the power-up pickup sound
            if (_audioSource != null && _powerupSFX != null)
            {
                _audioSource.PlayOneShot(_powerupSFX);
            }

            // Hide power-up instantly but keep it alive until sound finishes
            _spriteRenderer.enabled = false; // Hides the object
            _collider.enabled = false; // Disables collisions

            StartCoroutine(DestroyAfterSound());
        }
    }

    IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(_powerupSFX.length);
        Destroy(gameObject);
    }
}
