using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIinGame : MonoBehaviour
{
    [SerializeField] private Image hpImage;
    [SerializeField] private Text textHp;


    private void Start()
    {
        HpUpdate();
        PlayerBehaviour.player.hp.OnUIUpdate += () =>
        {
            HpUpdate();
        };
    }

    public void HpUpdate()
    {
        float hp = PlayerBehaviour.player.hp.GetHP();
        float hpMax = PlayerBehaviour.player.hp.GetHPMax();
        hpImage.fillAmount = hp / hpMax;
        textHp.text = hp + "/" + hpMax;
    }
}
