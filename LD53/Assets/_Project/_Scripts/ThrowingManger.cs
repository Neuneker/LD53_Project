using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingManger : MonoBehaviour
{

    [SerializeField] private bool _charging;

    [SerializeField] private GameObject _newspaper;
    [SerializeField] private float _throwForce;
    [SerializeField] private float _throwForceIncreaseMultiplier = 1;
    [SerializeField] private float _minThrowForce;
    [SerializeField] private float _maxThrowForce;
    [SerializeField] private float _loftAngle;

    // Start is called before the first frame update
    void Start()
    {
        _throwForce = _minThrowForce;
    }

    float deltaTime = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            deltaTime += Time.deltaTime * _throwForceIncreaseMultiplier;
            _throwForce = Mathf.PingPong(deltaTime, _maxThrowForce - _minThrowForce) + _minThrowForce;
        }
        if (Input.GetMouseButtonUp(0))
        {
            GameObject go = Instantiate(_newspaper);
            Vector3 targetPosition = Camera.main.transform.forward;
            targetPosition.y += _loftAngle;
            go.GetComponent<Rigidbody>().AddForce(targetPosition * _throwForce, ForceMode.VelocityChange);
            _throwForce = _minThrowForce;
            deltaTime = 0;
        }
    }
}