using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingPost : ActionItem
{
    public string[] dialogues;

    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogues, "Sign");

        print("Interacting with sign post!");
    }
}