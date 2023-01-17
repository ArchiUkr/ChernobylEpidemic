using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    public static float playerHealth = 100f;
    [SerializeField] Slider healthSlider;

    private void Update()
    {
       
        healthSlider.value = playerHealth;
        healthSlider.value.ToString();
    }

    public void TakePlayerDamage(float damage)
    {
        playerHealth -= damage;
        if(playerHealth <= 0)
        {
            GetComponent<DeadHandler>().HandleDeath();
        }
    }
}
