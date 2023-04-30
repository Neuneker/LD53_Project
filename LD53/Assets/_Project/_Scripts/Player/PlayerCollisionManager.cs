using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    [SerializeField] private GameSceneManager _gameSceneManager;

    [SerializeField] private LayerMask _powerupsLayer;
    [SerializeField] private LayerMask _obstaclesLayer;

    private void OnCollisionEnter(Collision collision)
    {
        if (_obstaclesLayer == (_obstaclesLayer | (1 << collision.gameObject.layer)))
        {
            _gameSceneManager.ResetLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_powerupsLayer == (_powerupsLayer | (1 << other.gameObject.layer))
)
        {
            other.GetComponentInParent<Collectable>().OnCollection(transform.root);
            Destroy(other.gameObject);
        }
        if (_obstaclesLayer == (_obstaclesLayer | (1 << other.gameObject.layer)) && transform.Find("Shield(Clone)") != null)
        {
            Destroy(transform.Find("Shield(Clone)").gameObject);
            Destroy(other.transform.root.gameObject);
        }       
    }
}
