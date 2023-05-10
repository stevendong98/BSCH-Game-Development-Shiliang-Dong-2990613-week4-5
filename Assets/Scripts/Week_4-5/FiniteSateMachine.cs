using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum States
{
    Patrol,
    Chase,
    
}

public class FiniteSateMachine : MonoBehaviour
{
    [SerializeField] States currentState;
    [SerializeField] Transform[] routes;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator anim;
    [SerializeField] Transform player;
    [SerializeField] float chaseDistance;

    int currentPatrolRouteIndex = 0;

    void Start()
    {
        currentState = States.Patrol;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == States.Patrol)
        Patroling();

        if (currentState == States.Chase)
            Chase();

        SetState();

    }


    void SetState()
    {
        if (Mathf.Abs(Vector3.Distance(agent.transform.position, player.position)) < chaseDistance)
        {
            currentState = States.Chase;
            anim.SetBool("Run",true);
            agent.speed = 7;
        }

        else
        {
            currentState = States.Patrol;
            anim.SetBool("Run", false);
            agent.speed = 6;
        }
           
    }

    void Chase()
    {
        agent.SetDestination(player.position);
    }

    void Patroling()
    {
        agent.SetDestination(routes[currentPatrolRouteIndex].position);

        if (HasReachedRoute())
        {
            currentPatrolRouteIndex++;
            if (currentPatrolRouteIndex >= routes.Length) currentPatrolRouteIndex = 0;
        }


    }

   bool HasReachedRoute()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }

        return false;
    }


}
