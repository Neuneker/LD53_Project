using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBarManager : MonoBehaviour
{

    [SerializeField] private Image _powerBarFill;
    
    public void SetFillAmount(float fillAmount)
    {
        _powerBarFill.fillAmount = fillAmount;
    }
}
