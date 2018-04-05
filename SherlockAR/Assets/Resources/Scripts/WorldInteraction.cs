using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//using UnityEngine.EventSystems;

public class WorldInteraction : MonoBehaviour
{
    private NavMeshAgent playerAgent;

    private void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            print("Press");

            GetInteraction();
        }
    }

    private void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit interactinInfo;

        if (Physics.Raycast(interactionRay, out interactinInfo, Mathf.Infinity))
        {
            playerAgent.updateRotation = true;

            GameObject interactedObject = interactinInfo.collider.gameObject;

            if (interactedObject.tag == "Enemy")
            {
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            }
            else if (interactedObject.tag == "Interactable Object")
            {
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            }
            else
            {
                //print(interactinInfo.collider.gameObject.name);
                playerAgent.stoppingDistance = 0;
                playerAgent.destination = interactinInfo.point;
            }
        }
    }
}