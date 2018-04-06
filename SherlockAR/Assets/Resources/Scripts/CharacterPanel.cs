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

    [SerializeField]
    private Text playerStatPrefab;

    [SerializeField]
    private Transform playerStatPanel;

    private List<Text> playerStatTexts = new List<Text>();

    //Equipped Weapon
    [SerializeField]
    private Sprite defaultWeaponSprite;

    private PlayerWeaponController playerWeaponController;

    [SerializeField]
    private Text weaponStatPrefab;

    [SerializeField]
    private Transform weaponStatPanel;

    [SerializeField]
    private Text weaponNameText;

    [SerializeField]
    private Image weaponIcon;

    private List<Text> weaponStatText = new List<Text>();

    // Use this for initialization
    private void Start()
    {
        playerWeaponController = player.GetComponent<PlayerWeaponController>();

        UIEventHandler.OnPlayerHealthChanged += UpdateHealth;
        UIEventHandler.OnStatsChanged += UpdateStats;
        UIEventHandler.OnItemEquipped += UpdateEquippedWeapon;
        UIEventHandler.OnPlayerLevelChange += UpdateLevel;
        InitalizeStats();
    }

    // Update is called once per frame
    private void UpdateHealth(int currentHealth, int maxHealth)
    {
        this.health.text = currentHealth.ToString();
        this.healthFill.fillAmount = (float)currentHealth / (float)maxHealth;
    }

    // Update is called once per frame
    private void UpdateLevel()
    {
        this.level.text = player.PlayerLevel.Level.ToString();
        this.levelFill.fillAmount = (float)player.PlayerLevel.CurrentExperience / (float)player.PlayerLevel.RequiredExperience;
    }

    private void InitalizeStats()
    {
        print("Start init");

        for (int i = 0; i < player.characterStats.stats.Count; i++)
        {
            playerStatTexts.Add(Instantiate(playerStatPrefab));
            playerStatTexts[i].transform.SetParent(playerStatPanel);
        }
        UpdateStats();
    }

    private void UpdateStats()
    {
        for (int i = 0; i < player.characterStats.stats.Count; i++)
        {
            playerStatTexts[i].text = player.characterStats.stats[i].StatName + ": "
                + player.characterStats.stats[i].GetCalculatedStatValue().ToString();
        }
    }

    private void UpdateEquippedWeapon(Item item)
    {
        weaponIcon.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.ObjectSlug);

        weaponNameText.text = item.ItemName;

        for (int i = 0; i < item.Stats.Count; i++)
        {
            weaponStatText.Add(Instantiate(weaponStatPrefab));
            playerStatTexts[i].transform.SetParent(weaponStatPanel);
            playerStatTexts[i].text = item.Stats[i].StatName + " : " + item.Stats[i].GetCalculatedStatValue().ToString();
        }
    }

    public void UnequipWeapon()
    {
        weaponNameText.text = "-";
        weaponIcon.sprite = defaultWeaponSprite;

        for (int i = 0; i < weaponStatText.Count; i++)
        {
            Destroy(weaponStatText[i].gameObject);
        }

        playerWeaponController.UnequipWeapon();
    }
}