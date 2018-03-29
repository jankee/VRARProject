using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance { get; set; }

    public List<string> dialogueLines = new List<string>();

    public string npcName;

    public GameObject dialoguePanel;

    private Button continueButton;

    private Text dialogueText, nameText;

    private int dialogueIndex;

    private void Awake()
    {
        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();

        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });

        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();

        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();

        dialoguePanel.SetActive(false);

        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddNewDialogue(string[] lines, string npcName)
    {
        dialogueIndex = 0;

        dialogueLines = new List<string>(lines.Length);

        dialogueLines.AddRange(lines);

        this.npcName = npcName;

        print(dialogueLines.Count);

        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;

        dialoguePanel.SetActive(true);
    }

    public void ContinueDialogue()
    {
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
}