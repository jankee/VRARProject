using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private Image hpImage;

    private float OriginHP;

    private Player player;

    // Use this for initialization
    private void Start()
    {
        player = gameObject.transform.root.GetComponentInChildren<Player>();

        HPInitialize();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void HPInitialize()
    {
        OriginHP = this.GetComponent<Player>().HP;

        hpImage.fillAmount = OriginHP / OriginHP;
    }

    public void TakeDamage(float value)
    {
        float tmpValue = hpImage.fillAmount * 100f;

        tmpValue -= value;

        hpImage.fillAmount = tmpValue / OriginHP;

        if (value == 10f)
        {
            StartCoroutine(player.FallIntoWater(2f));
        }
        else if (value == 20f)
        {
            StartCoroutine(player.TakeStun(1f));
        }

        if (tmpValue <= 0)
        {
            print("Game Over");
        }
    }

    public void TakeHP(float value)
    {
        float tmpValue = hpImage.fillAmount * 100f;

        if (tmpValue >= 100)
        {
            return;
        }

        tmpValue += value;

        hpImage.fillAmount = tmpValue / OriginHP;
    }
}