using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveToTargets : MonoBehaviour
{

    [SerializeField] protected Transform[] targets;
    protected int index = 0;
    protected NavMeshAgent agent;

    private bool IsArrived => agent.remainingDistance <= agent.stoppingDistance;

    protected Vector3 CurrentDestination => targets[index].position;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(CurrentDestination);

    }

    void Update()
    {
        if (IsArrived)
        {
            MoveToNextDestination();
        }
    }

    protected virtual void MoveToNextDestination()
    {
        index++;
        if (index >= targets.Length) index = 0;
        agent.SetDestination(CurrentDestination);
    }
}
