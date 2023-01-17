using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    NavMeshAgent navMeshAgent;

    [SerializeField] GameObject playerTarget;

    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    EnemyHealth health;

    private void Awake()
    {
       // playerTarget = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();


       
    }
     void Update()
    {
         if (health.IsDead()) {
             enabled = false;
             navMeshAgent.enabled = false;
         }
        
            distanceToTarget = Vector3.Distance(target.position, transform.position);

            if (isProvoked)
            {
                
                    EngageTarget();
                
            }
            else if (distanceToTarget <= chaseRange)
            {
                isProvoked = true;


            }
        
       
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }
  private void EngageTarget()
    {
        FacceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AtackTarget();
           
        }
    }

    private void AtackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }

    private void ChaseTarget()
    {
        if (navMeshAgent.isOnNavMesh)
        {
            navMeshAgent.SetDestination(playerTarget.transform.position);
        }
            GetComponent<Animator>().SetBool("attack", false);
            GetComponent<Animator>().SetTrigger("move");
            
        
    }

    private void FacceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        //transform.rotation  
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
