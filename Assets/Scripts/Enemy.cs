using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4;
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private AudioClip _enemyExplosionSFX;
    private Player _player;
    //handle to animator component
    private Animator _animator;
    private Collider2D _collider;
    private bool _isDestroying = false;
    private AudioSource _audioSource;



    //Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        //null check player

        if (_player == null)
        {
            Debug.LogError("Player not found in the scene.");
        }
        //assign the component to Anim
        _animator = GetComponent<Animator>(); // Assign the Animator component
        if (_animator == null)
        {
            Debug.LogError("Animator component is missing on the Enemy object.");
        }
        _collider = GetComponent<Collider2D>(); // Assign the Collider component
        if (_collider == null)
        {
            Debug.LogError("Collider component is missing on the Enemy object.");
        }
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("AudioSource component is missing on the Enemy object.");
        }

    }

    //Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * _speed);

        if (transform.position.y <= -5.5f)
        {
            float randomX = Random.Range(-9f, 9f);
            transform.position = new Vector3(randomX, 7.5f, 0);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (_isDestroying) return;
            //other.transform.GetComponent<Player>().Damage();  this is how to get any component you need. transform.GetComponent<>."whatever"();
            Player player = other.transform.GetComponent<Player>();
            //this is a null check
            if (player != null)
            {
                player.Damage();
            }
            StartDestruction();

            //trigger anim
            TriggerAnimation("OnEnemyDeath"); // Trigger death animation
            _speed = 0f;
            Destroy(this.gameObject, 2.3f);
        }
        else if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.AddScore(10);
            }
            StartDestruction();
            //trigger anim 
            TriggerAnimation("OnEnemyDeath");
            Destroy(gameObject, 2.3f);
        }
    }
    private void TriggerAnimation(string triggerName)
    {
        if (_animator != null)
        {
            _animator.SetTrigger(triggerName);
        }
    }
    private void StartDestruction()
    {
        _isDestroying = true; // Set the destroying flag
        if (_collider != null)
        {
            _collider.enabled = false; // Disable the collider to avoid further interactions
        }

        if (_animator != null)
        {
            _animator.SetTrigger("OnEnemyDeath"); // Trigger the death animation
        }
        if (_audioSource != null && _enemyExplosionSFX != null)
        {
            _audioSource.PlayOneShot(_enemyExplosionSFX);
        }

        Destroy(this.gameObject, 2.3f); // Adjust the delay to match the animation length
    }
}
