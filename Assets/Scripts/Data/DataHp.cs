using UnityEngine;
using System;

[System.Serializable]
public class DataHP
{
    [SerializeField] private int hp;
    [SerializeField] private int hpMax;

    public Death death = new Death();
    public Action OnUIUpdate;

    public DataHP()
    {
        Awaker.OnAwake += () =>
        {
            hp = hpMax;
        };
    }

    public int GetHP()
    {
        return hp;
    }
    public int GetHPMax()
    {
        return hpMax;
    }

    public void SetHPNow(int changeHPNow)
    {
        hp = changeHPNow;
        if (hp <= 0)
        {
            hp = 0;
            OnUIUpdate?.Invoke();
            death.InitDeath();
        }
        else if (hp > hpMax)
        {
            hp = hpMax;
        }
        OnUIUpdate?.Invoke();
    }
    public void SetHPMax(int changeHPMax)
    {
        hpMax = changeHPMax;
        if (hpMax <= 0)
        {
            hp = 0;
            OnUIUpdate?.Invoke();
            death.InitDeath();
        }
        OnUIUpdate?.Invoke();
    }


    public void ChangeHPNow(int changeHP)
    {
        int hpPluse = hp + changeHP;
        if (hpPluse <= 0)
        {
            hp = 0;
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
    public void ChangeHPMax(int changeHPMax)
    {
        hpMax += changeHPMax;
        OnUIUpdate?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        ChangeHPNow(-damage);
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
