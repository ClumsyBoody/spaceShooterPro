using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 20f;
    [SerializeField]
    private GameObject _explosionPrefab;
    [SerializeField]
    private AudioClip _explosionSFX; // Assign in Inspector

    private SpawnManager _spawnManager;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;
    private AudioSource _audioSource;

    private void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
        _audioSource = GetComponent<AudioSource>();

        if (_spawnManager == null) Debug.LogError("SpawnManager is not assigned.");
        if (_spriteRenderer == null) Debug.LogError("SpriteRenderer is missing.");
        if (_collider == null) Debug.LogError("Collider is missing.");
        if (_audioSource == null) Debug.LogError("AudioSource is missing.");
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            Explode();
        }
    }

    private void Explode()
    {
        // Hide asteroid instantly
        _spriteRenderer.enabled = false;
        _collider.enabled = false;

        // Spawn explosion effect
        if (_explosionPrefab != null)
        {
            Instantiate(_explosionPrefab, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogError("Explosion Prefab is not assigned.");
        }

        // Play explosion sound
        if (_audioSource != null && _explosionSFX != null)
        {
            _audioSource.PlayOneShot(_explosionSFX);
        }

        // Notify SpawnManager
        if (_spawnManager != null)
        {
            _spawnManager.StartSpawning();
        }

        // Destroy asteroid after the sound finishes
        StartCoroutine(DestroyAsteroidAfterSound());
    }

    private IEnumerator DestroyAsteroidAfterSound()
    {
        yield return new WaitForSeconds(_explosionSFX.length);
        Destroy(gameObject);
    }
}
