using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;





public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _speedBoostPrefab;
    [SerializeField]
    private GameObject _shieldPrefab;
    [SerializeField]
    private GameObject[] powerups;
    private bool _isSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        /*StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());*/
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(1f);

        while (_isSpawning == true) {

            float randomInterval = UnityEngine.Random.Range(0.001f, 1.5f);
            yield return new WaitForSeconds(0.05f);
            float randomX = UnityEngine.Random.Range(-9f, 9f);
            Vector3 posToSpawn = new Vector3(randomX, 7.5f, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab,posToSpawn,Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(randomInterval);
        }
    }

   IEnumerator SpawnPowerupRoutine()
{
        yield return new WaitForSeconds(1f);

        while (_isSpawning == true)

        {
            float randomInterval = UnityEngine.Random.Range(3f, 5f);
        

        float randomX = UnityEngine.Random.Range(-9f, 9f);
        Vector3 posToSpawn = new Vector3(randomX, 7.5f, 0);

            int randomPowerup = UnityEngine.Random.Range(0, 3);
            Instantiate(powerups[randomPowerup], posToSpawn, quaternion.identity);
            yield return new WaitForSeconds(randomInterval);

            // Randomly select which power-up to spawn
            /*int powerupType = UnityEngine.Random.Range(0, 3); // Range(0, 2) generates 0 or 1
                GameObject selectedPowerup = null;

                switch(powerupType)
            {
                    case 0:
                        selectedPowerup = _tripleShotPrefab;
                        break;

                    case 1:
                        selectedPowerup = _speedBoostPrefab;
                        break;

                    /*case 2:
                        selectedPowerup = _shieldPrefab; // Ensure you have a `_shieldPrefab` variable assigned in the inspector
                        break;

                    default:
                        Debug.LogWarning("Unknown Power-Up Type!");
                        break;
                    }

                // Use the selected power-up for instantiation
                if (selectedPowerup != null)
                {
                    GameObject newPowerup = Instantiate(selectedPowerup, posToSpawn, Quaternion.identity);
                }*/
        }
    }
    public void StartSpawning()
    {
        if (!_isSpawning)
        {
            _isSpawning = true;
            StartCoroutine(SpawnEnemyRoutine());
            StartCoroutine(SpawnPowerupRoutine());
        }
    }

    public void onPlayerDeath()
    {
        _isSpawning = false;
    }
}

