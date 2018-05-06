using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField]
    private Text health, level;

    [SerializeField]
    private Image healthFill, levelFill;

    [SerializeField]
    private Player player;

    private List<Text> playerStatText = new List<Text>();

    [SerializeField]
    private Text playerStatPrefab;

    [SerializeField]
    private Transform playerStatPanel;

    private void Start()
    {
        UIEventHandler.OnPlayerHealthChanged += UpdateHealth;
    }

    private void UpdateHealth(int currentHealth, int maxHealth)
    {
        this.health.text = currentHealth.ToString();

        this.healthFill.fillAmount = (float)currentHealth / (float)maxHealth;
    }

    private void InitializeStats()
    {
        for (int i = 0; i < player.characterStats.stats.Count; i++)
        {
            playerStatText.Add(Instantiate(playerStatPrefab));

            playerStatText[i].transform.SetParent(playerStatPanel);
        }
    }
}