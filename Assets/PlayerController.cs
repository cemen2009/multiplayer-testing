using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    public float agentSpeed;

    private void Start()
    {
        FindTarget();
    }

    private void Update()
    {
        NetworkManager.Singleton.OnServerStarted += FindTarget;

        try
        {
            agent.SetDestination(target.transform.position);
        }
        catch (NullReferenceException)
        {
            Debug.Log("no player");
        }


        agent.speed = agentSpeed;
    }

    private void FindTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
}
