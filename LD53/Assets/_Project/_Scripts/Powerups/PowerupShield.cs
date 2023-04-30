using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerup/Shield")]
public class PowerupShield : PowerupBase
{
    [SerializeField] private GameObject _playerShield;
    public override void OnPowerup(Transform player)
    {
        if (!player.Find("Shield(Clone)")) Instantiate(_playerShield,player.position,Quaternion.identity,player);
    }
}
