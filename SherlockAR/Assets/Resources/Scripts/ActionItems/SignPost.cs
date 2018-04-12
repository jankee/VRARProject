using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPost : ActionItem
{
    [SerializeField]
    private string[] dialogue;

    [SerializeField]
    private string npcName;

    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue, npcName);
    }
}