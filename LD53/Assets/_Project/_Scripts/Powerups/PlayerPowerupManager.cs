using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPowerupManager : MonoBehaviour
{
    [SerializeField] private KeyCode _powerupKey;
    [SerializeField] private PowerupBase _currentPowerup;
    public UnityEvent OnPowerupFail;
    public UnityEvent OnPowerupTriggered;
    [SerializeField] private PowerupUI _powerupUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_powerupKey))
        {
            TriggerPowerup();
        }
    }

    private void TriggerPowerup()
    {
        if (_currentPowerup == null)
        {
            OnPowerupFail?.Invoke();
            return;
        }
        OnPowerupTriggered?.Invoke();
        _currentPowerup.OnPowerup(transform);
        _currentPowerup = null;
        _powerupUI.ClearPowerup();
    }

    internal void SetPowerup(PowerupBase powerup)
    {
        _currentPowerup = powerup;
        _powerupUI.SetPowerup(powerup.icon);
    }
}
