using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public GameObject PC;

    public Image healthBar;
    public float healthAmount;

    private void Update()
    {
        healthAmount = PC.GetComponent<PlayerStats>().health;
    }

    public void UpdateHealth()
    {
        healthBar.fillAmount = healthAmount / 100f;
    }

}
