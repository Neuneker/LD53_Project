using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupBase : ScriptableObject
{
    public GameObject collectable;
    public Sprite icon;
    public abstract void OnPowerup(Transform player);
}
