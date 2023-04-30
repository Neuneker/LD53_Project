using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardMovement : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    private Rigidbody _rigidbody;
    [SerializeField] private float _power;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Debug.Log(_rigidbody.centerOfMass);
        _rigidbody.centerOfMass = new Vector3(_rigidbody.centerOfMass.x, 0, _rigidbody.centerOfMass.z);
        foreach (Wheel wheel in GetComponentsInChildren<Wheel>())
        {
            wheel.Steer(_inputManager.GetMoveInput().x);
            wheel.Accelerate(/*_inputManager.GetMoveInput().y * */1000);

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Wheel wheel in GetComponentsInChildren<Wheel>())
        {
            wheel.Steer(_inputManager.GetMoveInput().x);
            wheel.Accelerate(/*_inputManager.GetMoveInput().y * */_power);

        }
    }    
}
