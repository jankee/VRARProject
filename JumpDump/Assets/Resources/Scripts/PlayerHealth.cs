using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Photon.MonoBehaviour
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

        CloudSaveHP(hpImage.fillAmount);

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

        CloudSaveHP(hpImage.fillAmount);
    }

    private void CloudLoadHP()
    {
        if (photonView.owner.CustomProperties.ContainsKey("HP"))
        {
            hpImage.fillAmount = (float)photonView.owner.CustomProperties["HP"];

            int hp = (int)(hpImage.fillAmount * 100f);

            if (hp <= 0)
            {
            }
        }
    }

    public void CloudSaveHP(float hp)
    {
        //포톤 해쉬테이블(제네릭을 뺀 딕셔너리)생성
        ExitGames.Client.Photon.Hashtable hpInfo = new ExitGames.Client.Photon.Hashtable();

        //체력 포톤해쉬테이블에 체력값을 저장
        hpInfo.Add("HP", hp);

        //현재 캐릭터의 소유 클라이언트의 프로퍼티 체력 해쉬테이블을 저장
        photonView.owner.SetCustomProperties(hpInfo);
    }
}