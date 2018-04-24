using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    private NavMeshAgent playerAgent;

    private bool hasInteracted;

    private bool isEnemy;

    private void Update()
    {
        //플레이어가 있거나 길찾기를 하는중이 아니라면
        if (playerAgent != null && !playerAgent.pathPending)
        {
            // 플레이어가 스톱한 거리보다 작은면
            if (!hasInteracted && playerAgent.remainingDistance <= playerAgent.stoppingDistance)
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

    //플레이어 네비메쉬를 받아서 처리한다
    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        isEnemy = gameObject.tag == "Enemy";

        hasInteracted = false;

        this.playerAgent = playerAgent;

        playerAgent.stoppingDistance = 2;

        //플레이어 데스티네이션에 인터렉션 오브젝트의 위치 포지션을 준다
        playerAgent.destination = this.transform.position;
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }

    private void EnsureLookDirection()
    {
        playerAgent.updateRotation = false;

        Vector3 lookDirection = new Vector3(transform.position.x, playerAgent.transform.position.y, transform.position.z);

        playerAgent.transform.LookAt(lookDirection);

        playerAgent.updateRotation = true;
    }
}