using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class OpponentManager : MonoBehaviour
{
    NavMeshAgent agent;
    Vector3 _endPointPos;

    private void OnEnable()
    {
        EventManager.EndPointPosition += EndPointPosition;
    }
    private void OnDisable()
    {
        EventManager.EndPointPosition -= EndPointPosition;
    }
    void EndPointPosition(Vector3 endPos)
    {
        _endPointPos = endPos;
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = _endPointPos;
    }

    
    void Update()
    {
        PositionControl();
    }
    void PositionControl()
    {
        if (transform.position.z >= _endPointPos.z)
        {
            agent.speed = 0;
        }
    }
}
