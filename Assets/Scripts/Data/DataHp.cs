using UnityEngine;
using System;

[System.Serializable]
public class DataHP
{
    [SerializeField] public int hp;
    [SerializeField] public int hpMax;

    public Death death = new Death();
    public Action OnUIUpdate;

    public DataHP()
    {
        Awaker.OnAwake += () =>
        {
            hp = hpMax;
            OnUIUpdate?.Invoke();
        };
    }

    public void SetHP(int changeHP)
    {
        float hpPluse = hp + changeHP;
        if (hpPluse <= 0)
        {
            OnUIUpdate?.Invoke();
            death.InitDeath();
        }
        else if (hpPluse > hpMax)
        {
            hp = hpMax;
        }
        else
        {
            hp += changeHP;
        }
        OnUIUpdate?.Invoke();
    }


    public void SetHPMax(int changeHPMax)
    {
        hpMax += changeHPMax;
        OnUIUpdate?.Invoke();
    }


    public void TakeDamage(int damage)
    {
        SetHP(-damage);
    }
}

public class Death
{
    public Action OnInitDeath;
    public void InitDeath()
    {
        OnInitDeath?.Invoke();
    }
}
