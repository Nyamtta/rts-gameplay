using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TEst : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _meshAgent;
    [SerializeField] private Transform _target;

    private void Update()
    {
        //_meshAgent.destination = _target.position;
        _meshAgent.SetDestination(_target.position);
    }

}
