using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;    
    [SerializeField] Color SphereColor = Color.red;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
        
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= chaseRange)
        {
            navMeshAgent.SetDestination(target.position);
        }
    }
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = SphereColor;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
