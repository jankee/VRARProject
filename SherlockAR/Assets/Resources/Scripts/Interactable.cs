using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent playerAgent;

    private bool hasInteracted;

    private bool isEnemy;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        isEnemy = gameObject.tag == "Enemy";

        hasInteracted = false;

        this.playerAgent = playerAgent;

        playerAgent.stoppingDistance = 2.5f;

        //플레이어가 인터렉션 장소까지 올도록 한다
        playerAgent.destination = this.transform.position;

        Interact();
    }

    private void Update()
    {
        if (!hasInteracted && playerAgent != null && !playerAgent.pathPending)
        {
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                if (!isEnemy)
                {
                    Interact();
                }
                EnsureLookDirection();

                hasInteracted = true;
            }
        }
    }

    private void EnsureLookDirection()
    {
        playerAgent.updateRotation = false;
        Vector3 lookDirection = new Vector3(transform.position.x, playerAgent.transform.position.y, transform.position.z);
        playerAgent.transform.LookAt(lookDirection);
        playerAgent.updateRotation = true;
    }

    public virtual void Interact()
    {
        print("Interacting with base class!");
    }
}