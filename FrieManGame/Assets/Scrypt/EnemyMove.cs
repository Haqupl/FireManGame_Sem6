using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMove : MonoBehaviour
{

    public Transform target;
    private NavMeshAgent nma;
    // Use this for initialization
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
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
