using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image healthBar;

    private void Start()
    {
        healthBar.fillAmount = GetComponent<HealthAndDamage>().GetHealthRatio();
    }

    public void UpdateHealthBar(float newHealthRatio)
    {
        healthBar.fillAmount = newHealthRatio;
    }
}
