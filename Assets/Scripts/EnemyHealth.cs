using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    Rigidbody rb;

   public bool isDead = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public bool IsDead()
    {
        return isDead;
    }
    public void Damage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead)  return; 
        isDead = true;
        GetComponent<Animator>().SetTrigger("zombieDie");
        
        
    }
}
