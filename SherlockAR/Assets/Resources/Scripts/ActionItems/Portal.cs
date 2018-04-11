using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : ActionItem
{
    public Vector3 TeleportLocation { get; set; }

    [SerializeField]
    private Portal[] linkedPortals;

    private PortalController portalController;

    // Use this for initialization
    private void Start()
    {
        portalController = FindObjectOfType<PortalController>();

        TeleportLocation = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z);
    }

    public override void Interact()
    {
        portalController.ActivatePortal(linkedPortals);
        playerAgent.ResetPath();
    }
}