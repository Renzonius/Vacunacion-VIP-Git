using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCNav : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    [SerializeField] private Transform[] targets;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false; // IMPORTANTE para 2D
        StartCoroutine(ChangedPositionCoroutine());
    }

    private IEnumerator ChangedPositionCoroutine()
    {
        while (true)
        {
            agent.speed = Random.Range(.5f, 2f);
            int randomIndex = Random.Range(0, targets.Length);
            agent.SetDestination(targets[randomIndex].position);
            float randomTime = Random.Range(10f, 20f);
            yield return new WaitForSeconds(randomTime);
        }
    }

    void Update()
    {
        lookAtditectionToMove();
    }

 
    private void lookAtditectionToMove()
    {
        Vector3 direction = agent.velocity.normalized;
        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
        }
    }

}
