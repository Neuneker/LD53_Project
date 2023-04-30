using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Powerup/Time Dilation")]
public class PowerupTimeDilation : PowerupBase
{
    public GameObject go;
    public override void OnPowerup(Transform player)
    {
        Instantiate(go);
    }
}
