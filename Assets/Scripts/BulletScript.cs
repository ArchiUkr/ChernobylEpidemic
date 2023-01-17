using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float speedBullet;
    [SerializeField] float timeToLife;

    Vector3 bulletDestination;


    bool isDestinationComplete()
    {
        if (bulletDestination == Vector3.zero)
            return false;

        Vector3 directionToDestination = bulletDestination - transform.position;
        float dot = Vector3.Dot(directionToDestination, transform.forward);

        if (dot < 0)
            return true;

        return false;
    }
    private void Start()
    {
        Destroy(gameObject, timeToLife);
    }

    private void Update()
    {

        if (isDestinationComplete())
        {
            Destroy(gameObject);
            return;
        }

        transform.Translate(Vector3.forward * speedBullet * Time.deltaTime);
        if (bulletDestination != Vector3.zero)
            return;
    }

    

}
