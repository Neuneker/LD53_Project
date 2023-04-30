using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _speedText;
    [SerializeField] private Rigidbody _playerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _speedText.text = "MPH: " + ((int)_playerRigidbody.velocity.magnitude).ToString();
    }
}
