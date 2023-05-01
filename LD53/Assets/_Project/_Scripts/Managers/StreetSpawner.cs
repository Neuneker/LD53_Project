using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetSpawner : MonoBehaviour
{
    [SerializeField] private int _spawnDistance;
    [SerializeField] private GameObject _streetPrefab;
    [SerializeField] private float _spawnPositionMultiplier;
    private List<GameObject> _streets;
    [SerializeField] private Transform _playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        _streets = new List<GameObject>();
        for (int index = 0; index < _spawnDistance; index++) 
        {
            GameObject temp = Instantiate(_streetPrefab);
            temp.transform.position = new Vector3(0, 0, _spawnPositionMultiplier * index);
            temp.transform.parent = this.transform;
            _streets.Add(temp);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(_streets[_streets.Count - 1].transform.position,_playerTransform.position) < _spawnPositionMultiplier * (_spawnDistance-5))
        {
            Destroy(_streets[0]);
            _streets.RemoveAt(0);
            GameObject temp = Instantiate(_streetPrefab);
            temp.transform.position = _streets[_streets.Count - 1].transform.position + new Vector3(0,0,_spawnPositionMultiplier);
            temp.transform.parent = this.transform;
            _streets.Add(temp);
        }
    }
}
