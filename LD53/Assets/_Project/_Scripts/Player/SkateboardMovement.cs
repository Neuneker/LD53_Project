using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardMovement : MonoBehaviour
{
    [SerializeField] private KeyCode _resetScene;
    [SerializeField] private InputManager _inputManager;
    private Rigidbody _rigidbody;
    [SerializeField] private float _power;

    private float runtime;
    internal void Turbo(float boostTime)
    {
        _currentForce = _turboForce;
        StartCoroutine(ResetTurbo(boostTime));
    }

    private IEnumerator ResetTurbo(float boostTime)
    {
        yield return new WaitForSeconds(boostTime);
        _currentForce = _force;
    }


    [SerializeField] private float _force;
    [SerializeField] private float _turboForce;
    private float _currentForce;

    public bool usePhysics = false;
    private float playerZ;
    private float oldVelocity;

    // Start is called before the first frame update
    void Start()
    {
        _currentForce = _force;
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

    private void Update()
    {
        if (Input.GetKeyDown(_resetScene)) ResetPlayer();
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
            Vector3 newDir;
            if (runtime > .5f)
                newDir = Quaternion.Euler(0, _inputManager.GetMoveInput().x, 0) * transform.forward;
            else
                newDir = Vector3.forward;
            _rigidbody.MoveRotation(Quaternion.Euler(newDir));
            newDir.y = 0;
            transform.forward = newDir;
            Debug.Log((transform.forward * _force).y);
            _rigidbody.AddForce(transform.forward * _currentForce, ForceMode.Force);

        }
        playerZ = transform.position.z;

        runtime += Time.deltaTime;
        if (_rigidbody.velocity.magnitude < oldVelocity / 2 && runtime > 3)
        {
            ResetPlayer();
        }
        oldVelocity = _rigidbody.velocity.magnitude;
    }
    public void ResetPlayer()
    {
        runtime = 0;
        Debug.Log("reset");
        StopAllCoroutines();
        _currentForce = _force;
        _rigidbody.velocity = Vector3.zero;
        transform.position = new Vector3(0, .5f, playerZ);
        transform.forward = Vector3.forward;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
