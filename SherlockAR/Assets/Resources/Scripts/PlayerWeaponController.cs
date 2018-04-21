using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerHand;

    public GameObject EquippedWeapon { get; set; }

    private IWeapon equippedWeapon;

    private CharacterStats characterStats;

    public void Start()
    {
        characterStats = this.GetComponent<CharacterStats>();
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
            characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }

        EquippedWeapon = Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug),
            playerHand.transform.position, playerHand.transform.rotation);

        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();

        equippedWeapon.Stats = itemToEquip.Stats;

        EquippedWeapon.transform.SetParent(playerHand.transform);

        characterStats.AddStatBonus(itemToEquip.Stats);

        print(equippedWeapon.Stats[0].GetCalculatedStatValue());
    }

    public void PerformWeaponAttack()
    {
        print("PerformSpecialAttack");
        EquippedWeapon.GetComponent<IWeapon>().performAttack();
    }

    public void PerformSpecialAttack()
    {
        EquippedWeapon.GetComponent<IWeapon>().PerformSpecialAttack();
    }
}