using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerup/_Powerup List")]
public class PowerupList : ScriptableObject
{
    public PowerupBase[] _powerupList;

    internal PowerupBase GetRandom()
    {
        return _powerupList[UnityEngine.Random.Range(0, _powerupList.Length)];
    }
}
