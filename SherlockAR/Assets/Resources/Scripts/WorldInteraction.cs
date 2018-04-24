using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour
{
    private NavMeshAgent playerAgent;

    private void Start()
    {
        playerAgent = this.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();
        }
    }

    private void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactionObject = interactionInfo.collider.gameObject;
            if (interactionObject.tag == "Enemy")
            {
                interactionObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            }
            //인터렉션 오브젝트가 아니면 그 위치까지 이동
            else if (interactionObject.tag == "Interactable Object")
            {
                interactionObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            }
            else
            {
                playerAgent.stoppingDistance = 0;
                //바닥을 찍었을 경우
                playerAgent.destination = interactionInfo.point;
            }
        }
    }
}