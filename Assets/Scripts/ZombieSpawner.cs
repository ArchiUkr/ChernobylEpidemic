using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] GameObject theZombie;
    [SerializeField] int xPos;
    [SerializeField] int zPos;
    [SerializeField] int enemyCount;


    NavMeshAgent navMeshAgent;

    private void Start()
    {
        StartCoroutine(EnemyDrop());
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 10)
        {
            xPos = Random.Range(20, 40);
            zPos = Random.Range(1, 10);
            Instantiate(theZombie, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
