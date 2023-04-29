using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField] private bool _powered;
    [SerializeField] private float _maxAngle;
    [SerializeField] private float offset;
    [SerializeField] private float _brakePressure;
    private float _turnAngle;
    private WheelCollider _wheelCollider;

    // Start is called before the first frame update
    void Start()
    {
        _wheelCollider = GetComponent<WheelCollider>();
        _wheelCollider.ConfigureVehicleSubsteps(5, 12, 15);
    }


    public void Steer(float steerInput)
    {
        _turnAngle = steerInput * _maxAngle + offset;
        _wheelCollider.steerAngle = _turnAngle;
    }

    public void Accelerate(float powerInput)
    {
        if (powerInput == 0) _wheelCollider.brakeTorque = _brakePressure;
        else _wheelCollider.brakeTorque = 0;
        if (_powered) _wheelCollider.motorTorque = powerInput;
        else _wheelCollider.brakeTorque = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
