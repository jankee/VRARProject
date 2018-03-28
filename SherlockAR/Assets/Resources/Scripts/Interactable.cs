using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    public NavMeshAgent playerAgent;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        this.playerAgent = playerAgent;

        playerAgent.stoppingDistance = 3f;

        //플레이어가 인터렉션 장소까지 올도록 한다
        playerAgent.destination = this.transform.position;

        Interact();
    }

    public virtual void Interact()
    {
        print("Interacting with base class!");
    }
}