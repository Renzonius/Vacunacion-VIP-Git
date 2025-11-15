using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCNav : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    [SerializeField] private bool isMoving;
    [SerializeField] private bool isStuck;
    [SerializeField] float stuckTimer = 2f;
    [SerializeField] private PositionController positionController;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Transform positionSelected;

    [Header("ANIMATIONS")]
    [SerializeField] private Animator animator;
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false; // IMPORTANTE para 2D
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        StartCoroutine(ChangedPositionCoroutine());

    }


    private void OnCollisionStay2D(Collision2D col)
    {

        isStuck = true;
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        isStuck = false;
    }


    private IEnumerator ChangedPositionCoroutine()
    {

        while (true)
        {
            if (positionController.freePositions.Count < 0) break;
            agent.speed = Random.Range(.5f, 2f);
            LeaveCurrentPosition();
            SelectRandomPosition();

            StartCoroutine(nameof(GoToPositionCoroutine));
            float randomTime = Random.Range(20f, 45f);
            isMoving = true;
            UpdateAnimation(isMoving, agent.speed);
            yield return new WaitForSeconds(randomTime);
        }

    }


    private void UpdateAnimation(bool IsMoving, float AgentSpeed)
    {
        animator.speed = AgentSpeed;
        animator.SetBool("isWalking", IsMoving);
    }

    private IEnumerator GoToPositionCoroutine()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, positionSelected.position) > 0.1f)
            {
                if (!isStuck) lookAtditectionToMove();
            }
            else
            {
                transform.position = positionSelected.localPosition;
                transform.rotation = positionSelected.localRotation;
                isMoving = false;
                animator.SetBool("isWalking", isMoving);
                break;
            }
            yield return null;
        }
    }

    private void SelectRandomPosition()
    {
        int randomIndex = Random.Range(0, positionController.freePositions.Count);
        positionSelected = positionController.freePositions[randomIndex].transform;
        positionController.lockPositions.Add(positionController.freePositions[randomIndex]);
        positionController.freePositions.RemoveAt(randomIndex);
        agent.SetDestination(positionSelected.position);
    }

    private void LeaveCurrentPosition()
    {
        Vector3 currentPos = agent.destination;
        currentPos.z = 0;
        foreach (Transform pos in positionController.lockPositions)
        {
            if (pos.transform.localPosition == currentPos)
            {
                positionController.freePositions.Add(pos);
                positionController.lockPositions.Remove(pos);
                break;
            }
        }

    }
    private void lookAtditectionToMove()
    {
        Vector3 direction = agent.velocity.normalized;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
        }

    }

}
