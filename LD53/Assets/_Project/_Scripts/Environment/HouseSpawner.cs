using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    public GameObject[] housePrefabs;

    private List<Transform> _spawnLocations;
    public GameObject targetPrefab;
    public float targetChance;
    
    // Start is called before the first frame update
    void Start()
    {
        //SpawnHouse
        Instantiate(housePrefabs[Random.Range(0, housePrefabs.Length)], transform.position, transform.rotation, transform);
        //FindTargetSpawnPoints
        if (Random.value > targetChance) return;
        _spawnLocations = new List<Transform>();
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child.tag == "targetSpawn")
            {
                _spawnLocations.Add(child);
            }
        }

        Instantiate(targetPrefab, _spawnLocations[Random.Range(0, _spawnLocations.Count)].position, Quaternion.identity, transform);

    }

}
