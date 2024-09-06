using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Color gizmoColor = Color.red;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    [SerializeField] Transform target;

    bool isProvoked = false;
    float distanceFromTarget = Mathf.Infinity;
    NavMeshAgent agent;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>().transform;
        agent = GetComponent<NavMeshAgent>();
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void Update()
    {
        distanceFromTarget = Vector3.Distance(transform.position, target.position);

        if(isProvoked)
        {
            
            EngageTarget();
        }
        else if(distanceFromTarget <= chaseRange)
        {
            isProvoked = true;
        }

        
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    void EngageTarget()
    {
        FaceTarget();
        if (distanceFromTarget >= agent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceFromTarget <= agent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        agent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
        Debug.Log("I kill you!");
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnSpeed);



    }

}
