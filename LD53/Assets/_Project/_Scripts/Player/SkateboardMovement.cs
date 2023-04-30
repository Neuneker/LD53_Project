using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardMovement : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    private Rigidbody _rigidbody;
    [SerializeField] private float _power;
    [SerializeField] private float _force;

    public bool usePhysics = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (usePhysics)
        {
            Debug.Log(_rigidbody.centerOfMass);
            _rigidbody.centerOfMass = new Vector3(0, 0, 0);
            foreach (Wheel wheel in GetComponentsInChildren<Wheel>())
            {
                wheel.Steer(_inputManager.GetMoveInput().x);
                wheel.Accelerate(/*_inputManager.GetMoveInput().y * */1000);

            }
        }
        else
        {
            _rigidbody.centerOfMass = new Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (usePhysics)
        {
            foreach (Wheel wheel in GetComponentsInChildren<Wheel>())
            {
                wheel.Steer(_inputManager.GetMoveInput().x);
                wheel.Accelerate(/*_inputManager.GetMoveInput().y * */_power);

            }
        }
        else
        {
            Vector3 newDir = Quaternion.Euler(0, _inputManager.GetMoveInput().x, 0) * transform.forward;
            _rigidbody.MoveRotation(Quaternion.Euler(newDir));
            newDir.y = 0;
            transform.forward = newDir;
            Debug.Log((transform.forward * _force).y);
            _rigidbody.AddForce(transform.forward * _force, ForceMode.Force);
        }
    }    
}
