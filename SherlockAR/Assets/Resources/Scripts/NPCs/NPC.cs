using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    [SerializeField]
    private string[] dialogue;

    [SerializeField]
    private string name;

    private void Start()
    {
        //dialogue = new string[];
    }

    public override void Interact()
    {
        //다이얼로그 시작
        DialogueSystem.Instance.AddNewDialogue(dialogue, name);
        Debug.Log("Interacting with NPC.");
    }
}