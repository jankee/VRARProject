using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{
    public bool AssignedQuest { get; set; }
    public bool Helped { get; set; }
    private Quest Quest { get; set; }

    [SerializeField]
    private GameObject quests;

    [SerializeField]
    private string questType;

    public override void Interact()
    {
        if (!AssignedQuest && !Helped)
        {
            base.Interact();

            AssighQuest();
        }
        else if (AssignedQuest && !Helped)
        {
            CheckQuest();
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Thanks for that stuff that one time.", "More Dialogue" }, name);
        }
    }

    private void AssighQuest()
    {
        AssignedQuest = true;
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
    }

    private void CheckQuest()
    {
        if (Quest.Completed)
        {
            Quest.GiveReward();
            Helped = true;
            AssignedQuest = false;
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Thanks for that! Here's your reward.", "More Dialogue" }, name);
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "You're still in the middle of helping me. Get back at it." }, name);
        }
    }
}