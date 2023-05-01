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
        icon.gameObject.SetActive(true);
    }

    public void ClearPowerup()
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false);
    }
}
