using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Singleton<PlayerHealth>
{
    [SerializeField]
    private Image hpImage;

    private float OriginHP;

    private Animator anim;

    // Use this for initialization
    private void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();

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

        StartCoroutine(FallIntoWater(2f));

        if (tmpValue <= 0)
        {
            print("Game Over");
        }
    }

    private IEnumerator FallIntoWater(float value)
    {
        InputManager.Instance.IsMoved = true;

        anim.SetBool("WATER", true);

        yield return new WaitForSeconds(value);

        InputManager.Instance.IsMoved = false;

        anim.SetBool("WATER", false);
    }
}