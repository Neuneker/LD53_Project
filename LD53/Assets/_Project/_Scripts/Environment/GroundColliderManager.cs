using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColliderManager : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 v3 = player.position;
        v3.x = 0;
        v3.y = -0.1f;
        transform.position = v3;
    }
}
