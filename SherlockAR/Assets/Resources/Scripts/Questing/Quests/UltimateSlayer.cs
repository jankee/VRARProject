using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateSlayer : Quest
{
    // Use this for initialization
    private void Start()
    {
        print("Ultimate Slayer assigned.");
        QuestName = "Ultimate Slayer";
        Description = "Kill a bunch of stuff.";
        ItemReward = ItemDatabase.Instance.GetItem("potion_log");
        ExperienceReward = 100;

        Goals.Add(new KillGoal(this, 0, "Kill 5 Slimes", false, 0, 5));
        Goals.Add(new KillGoal(this, 1, "Kill 2 Vampires", false, 0, 2));

        Goals.ForEach(g => g.Init());
    }

    // Update is called once per frame
    private void Update()
    {
    }
}