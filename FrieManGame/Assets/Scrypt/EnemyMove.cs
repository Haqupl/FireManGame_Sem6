using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMove : MonoBehaviour
{

    private Transform target;
    private NavMeshAgent nma;
    private EnemyAnimController enamyController;
    EnemyHealth enemyHealth;


    // Use this for initialization
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        nma.updateRotation = false;
        enamyController = GetComponent<EnemyAnimController>();
        enemyHealth = GetComponent<EnemyHealth>();

        GameObject[] objPlayers = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < objPlayers.Length; i++)
        {
            if (objPlayers[i].name == "Player")
            {
                target = objPlayers[i].transform;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!nma.isOnNavMesh)
            return;

        if (target == null || enemyHealth.IsDead)
        {
            nma.isStopped = true;
            enamyController.Move(Vector3.zero, false, false);
            return;
        }

        if (target != null)
        {
            nma.SetDestination(target.position);
        }

        if (nma.remainingDistance > nma.stoppingDistance)
        {
            enamyController.Move(nma.desiredVelocity, false, false);
        }
        else
        {
            enamyController.Move(Vector3.zero, false, false);
        }
    }
}
