using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private KeyCode _timeDialationKey;

    [SerializeField] private float _timeDialation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(_timeDialationKey))
        {
            Time.timeScale = _timeDialation;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
