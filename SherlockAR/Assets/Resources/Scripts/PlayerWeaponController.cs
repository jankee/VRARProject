using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerHand;

    public GameObject EquippedWeapon { get; set; }

    private Transform spawnProjectile;

    private IWeapon equippedWeapon;

    private Item currentlyEquippedWeapon;

    private CharacterStats characterStats;

    public void Start()
    {
        spawnProjectile = transform.GetChild(1);

        characterStats = this.GetComponent<Player>().characterStats;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            PerformWeaponAttack();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            PerformSpecialAttack();
        }
    }

    public void EquipWeapon(Item itemToEquip)
    {
        if (EquippedWeapon != null)
        {
            InventoryController.Instance.GiveItem(currentlyEquippedWeapon.ObjectSlug);
            characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }

        EquippedWeapon = Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug),
            playerHand.transform.position, playerHand.transform.rotation);

        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();

        //스테프일때
        if (EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
        {
            //무기에 spawnProjectile을 넣어둔다
            EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = spawnProjectile;
        }
        else if (EquippedWeapon.GetComponent<Sword>() != null)
        {
            EquippedWeapon.GetComponent<Sword>().CharacterStats = characterStats;
        }

        EquippedWeapon.transform.SetParent(playerHand.transform);

        equippedWeapon.Stats = itemToEquip.Stats;

        currentlyEquippedWeapon = itemToEquip;

        List<BaseStat> tmpBase = itemToEquip.Stats;

        characterStats.AddStatBonus(tmpBase);

        UIEventHandler.ItemEquipped(itemToEquip);
    }

    public void PerformWeaponAttack()
    {
        equippedWeapon.performAttack(CalculateDamage());
    }

    public void PerformSpecialAttack()
    {
        EquippedWeapon.GetComponent<IWeapon>().PerformSpecialAttack();
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(playerHand.transform.position, playerHand.transform.localPosition + new Vector3(10, 0, 0));
    }

    private int CalculateDamage()
    {
        int damageToDeal = (characterStats.GetStat(BaseStat.BaseStatType.Power).GetCalculatedStatValue() * 2)
            + Random.Range(2, 8);

        return damageToDeal += CalculateCrit(damageToDeal);
    }

    private int CalculateCrit(int damage)
    {
        if (Random.value <= 0.1f)
        {
            int critDamage = (int)(damage * Random.Range(0.25f, 0.5f));

            return critDamage;
        }

        return 0;
    }
}