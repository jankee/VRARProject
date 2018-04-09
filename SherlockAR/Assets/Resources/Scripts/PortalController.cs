using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalController : MonoBehaviour
{
    [SerializeField]
    private Button button;

    private Portal[] portal;
    private Player player;
    private GameObject panel;

    // Use this for initialization
    private void Start()
    {
        player = FindObjectOfType<Player>();

        panel = transform.Find("Panel_Portal").gameObject;
    }

    private void ActivatePortal(Portal[] portals)
    {
        panel.SetActive(true);

        for (int i = 0; i < portals.Length; i++)
        {
            Button portalButton = Instantiate(button, panel.transform);

            portalButton.GetComponentInChildren<Text>().text = portals[i].name;

            int x = i;

            portalButton.onClick.AddListener(delegate { OnPortalButtonClick(x); });
        }
    }

    private void OnPortalButtonClick(int PortalIndex)
    {
    }
}