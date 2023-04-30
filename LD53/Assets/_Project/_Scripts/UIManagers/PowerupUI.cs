using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupUI : MonoBehaviour
{
    public Image icon;
    public void SetPowerup(Sprite sprite)
    {
        icon.sprite = sprite;
    }

    public void ClearPowerup()
    {
        icon.sprite = null;
    }
}
