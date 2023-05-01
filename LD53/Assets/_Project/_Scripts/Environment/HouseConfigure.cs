using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseConfigure : MonoBehaviour
{
    public GameObject[] roofs;
    public GameObject[] windows;
    public GameObject[] doors;
    public Transform[] windowSpawns;
    public Transform[] doorSpawns;
    public Transform roofSpawn;

    private List<Transform> _spawnLocations;
    public GameObject targetPrefab;
    public float targetChance;

    // Start is called before the first frame update
    void Start()
    {
        SpawnRoof();
        SpawnDoor();
        SpawnWindows();
        SpawnTarget();
    }

    void SpawnTarget()
    {
        if (Random.value > targetChance) return;
        _spawnLocations = new List<Transform>();
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child.tag == "targetSpawn" && child.childCount > 0)
            {
                _spawnLocations.Add(child);
            }
        }

        Instantiate(targetPrefab, _spawnLocations[Random.Range(0, _spawnLocations.Count)].position, Quaternion.identity, transform);
    }

    void SpawnRoof()
    {
        Instantiate(GetRandom(roofs),roofSpawn.position, roofSpawn.rotation,roofSpawn);
    }

    void SpawnDoor()
    {
        Transform t = GetRandom(doorSpawns);
        Instantiate(GetRandom(doors), t.position, t.rotation, t);
    }
    void SpawnWindows()
    {
        GameObject windowType = GetRandom(windows);
        foreach (Transform child in windowSpawns)
        {
            if (Random.value < .7f && child.childCount == 0)
            {
                Instantiate(windowType, child.position, child.rotation, child);
            }
        }        
    }

    GameObject GetRandom(GameObject[] gos)
    {
        return gos[Random.Range(0, gos.Length)];
    }
    Transform GetRandom(Transform[] transforms)
    {
        return transforms[Random.Range(0, transforms.Length)];
    }

}
