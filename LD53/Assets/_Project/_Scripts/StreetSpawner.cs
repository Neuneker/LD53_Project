using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetSpawner : MonoBehaviour
{
    [SerializeField] private int _spawnDistance;
    [SerializeField] private GameObject _streetPrefab;
    [SerializeField] private float _spawnPositionMultiplier;
    private List<GameObject> _streets;

    // Start is called before the first frame update
    void Start()
    {
        _streets = new List<GameObject>();
        for (int index = 0; index < _spawnDistance; index++) 
        {
            GameObject temp = Instantiate(_streetPrefab);
            temp.transform.position = new Vector3(-33, 0, _spawnPositionMultiplier * index);
            temp.transform.parent = this.transform;
            _streets.Add(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
