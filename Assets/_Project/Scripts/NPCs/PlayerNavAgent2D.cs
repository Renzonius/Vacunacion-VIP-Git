using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNavAgent2D : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false; // IMPORTANTE para 2D
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            agent.SetDestination(mousePos);
        }
    }
}
