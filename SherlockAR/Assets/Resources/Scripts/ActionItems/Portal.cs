using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : ActionItem
{
    public Vector3 TeleportLocation { get; set; }

    [SerializeField]
    private Portal[] linkedPortals;

    // Use this for initialization
    private void Start()
    {
        TeleportLocation = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z);
    }

    public override void Interact()
    {
    }
}