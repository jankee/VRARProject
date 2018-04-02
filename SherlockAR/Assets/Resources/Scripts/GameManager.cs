using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Camera sceneCamera;

    [SerializeField]
    private Camera arCamera;

    [SerializeField]
    private GameObject changeButtonPanel;

    [SerializeField]
    private GameObject dialoguePanel;

    private string[] StartString = { "편지가 도착 했습니다.", "확인 부탁드립니다" };

    //private int one = 1;
    //private int

    // Use this for initialization
    private void Start()
    {
        StartScripts();
        dialoguePanel.SetActive(true);
    }

    // Update is called once per frame
    public void ChangeCamera()
    {
        arCamera.depth = 1;
        sceneCamera.depth = 0;

        dialoguePanel.SetActive(false);
        changeButtonPanel.SetActive(false);
    }

    public void StartScripts()
    {
        DialogueSystem.Instance.AddNewDialogue(StartString, "Letter");
    }
}