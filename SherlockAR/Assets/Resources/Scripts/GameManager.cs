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

    //private int one = 1;
    //private int

    // Use this for initialization
    private void Start()
    {
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
}