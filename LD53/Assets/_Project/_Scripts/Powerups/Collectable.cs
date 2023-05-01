using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private PowerupBase _powerup;
    [SerializeField] private PowerupList _powerupList;
    [SerializeField] private GameObject[] _obstaclesList;
    [SerializeField] private float _rotationSpeed;
    private Transform _collectable;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _powerUpSpawnRate;
    [SerializeField] private float _obstacleSpawnRate;
    [SerializeField] private float _sceondObstacleSpawnRate;

    private void Start()
    {
        if (!ScoreManager.singleton.started) return;
        if (Random.value < _powerUpSpawnRate)
        {
            int rand = Random.Range(0, _spawnPoints.Count);
            _powerup = _powerupList.GetRandom();
            _collectable = Instantiate(_powerup.collectable, _spawnPoints[rand].position, Quaternion.identity, this.transform).transform;
            _spawnPoints.RemoveAt(rand);
        }
        if (ScoreManager.singleton.timeSinceStart < 10) return;
        if (Random.value < _obstacleSpawnRate)
        {
            int rand = Random.Range(0, _spawnPoints.Count);
            int randObstacle = Random.Range(0, _obstaclesList.Length);
            Instantiate(_obstaclesList[randObstacle], _spawnPoints[rand].position, Quaternion.identity);
            _spawnPoints.RemoveAt(rand);
        }
        if (ScoreManager.singleton.timeSinceStart < 25) return;
        if (Random.value < _obstacleSpawnRate)
        {
            int rand = Random.Range(0, _spawnPoints.Count);
            int randObstacle = Random.Range(0, _obstaclesList.Length);
            Instantiate(_obstaclesList[randObstacle], _spawnPoints[rand].position, Quaternion.identity);
            _spawnPoints.RemoveAt(rand);
        }
    }

    private void Update()
    {
        if (_collectable != null) _collectable.Rotate(Vector3.up, Time.deltaTime * _rotationSpeed);
    }

    public void OnCollection(Transform player)
    {
        player.GetComponent<PlayerPowerupManager>().SetPowerup(_powerup);
    }
}
