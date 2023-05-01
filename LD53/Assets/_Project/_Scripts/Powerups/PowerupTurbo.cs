using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Powerup/Turbo Powerup")]
public class PowerupTurbo : PowerupBase
{
    public float boostTime;

    public override void OnPowerup(Transform player)
    {

        GameObject.FindObjectOfType<SkateboardMovement>().Turbo(boostTime);
    }
}
