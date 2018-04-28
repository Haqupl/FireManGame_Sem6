using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMove : MonoBehaviour
{

    private Transform target;
    private NavMeshAgent nma;
    // Use this for initialization
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
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
        if (target != null)
        {
            nma.SetDestination(target.position);
        }
        if (target == null)
        {
            nma.Stop();
        }
    }
}
