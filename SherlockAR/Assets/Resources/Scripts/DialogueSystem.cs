using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    //싱글톤
    public static DialogueSystem Instance { get; set; }

    [SerializeField]
    private GameObject dialoguePanel;

    private string npcName;

    private List<string> dialogueLines = new List<string>();

    private Button continueButton;

    private Text dialogueText, nameText;

    private int dialogueIndex;

    private void Awake()
    {
        continueButton = dialoguePanel.transform.GetChild(0).GetComponent<Button>();

        dialogueText = dialoguePanel.transform.GetChild(1).GetComponent<Text>();

        nameText = dialoguePanel.transform.GetChild(2).GetChild(0).GetComponent<Text>();

        //버튼 이벤트 처리
        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });

        dialoguePanel.SetActive(false);

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddNewDialogue(string[] lines, string npcName)
    {
        dialogueIndex = 0;

        //리스트에 스트링 배열을 넣어 줌
        dialogueLines = new List<string>(lines);
        //dialogueLines.AddRange(lines);

        this.npcName = npcName;

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