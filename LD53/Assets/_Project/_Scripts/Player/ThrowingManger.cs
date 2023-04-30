using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingManger : MonoBehaviour
{

    [SerializeField] private bool _charging;
    [SerializeField] private Transform _throwPoint;
    [SerializeField] private GameObject _newspaper;
    [SerializeField] private float _throwForce;
    [SerializeField] private float _throwForceIncreaseMultiplier = 1;
    [SerializeField] private float _minThrowForce;
    [SerializeField] private float _maxThrowForce;
    [SerializeField] private float _loftAngle;
    [SerializeField] private bool _relativeThrowing;
    [SerializeField] private PowerBarManager _powerBarManager;

    [SerializeField] private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _throwForce = _minThrowForce;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) return;

        if (Input.GetMouseButton(0))
        {
            _throwForce += Time.deltaTime * _throwForceIncreaseMultiplier;
            _throwForce = Mathf.Clamp(_throwForce, _minThrowForce, _maxThrowForce);
            _animator.SetBool("Charging", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            GameObject go = Instantiate(_newspaper);
            go.transform.position = _throwPoint.position;
            Vector3 targetPosition = Camera.main.transform.forward;
            targetPosition.y += _loftAngle;
            
            if (_relativeThrowing) go.GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity + (targetPosition * _throwForce), ForceMode.VelocityChange);
            else go.GetComponent<Rigidbody>().AddForce(targetPosition * _throwForce, ForceMode.VelocityChange);
            go.GetComponent<NewspaperManager>().throwPower = (_throwForce - _minThrowForce) / (_maxThrowForce - _minThrowForce);
            _throwForce = _minThrowForce;
            _animator.SetBool("Charging", false);

        }

        _powerBarManager.SetFillAmount((_throwForce - _minThrowForce) / (_maxThrowForce - _minThrowForce));
    }
}
