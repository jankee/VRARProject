using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent playerAgent;

    private bool hasInteracted;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        hasInteracted = false;

        this.playerAgent = playerAgent;

        playerAgent.stoppingDistance = 3f;

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
                Interact();

                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
        print("Interacting with base class!");
    }
}