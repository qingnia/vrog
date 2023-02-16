using System;
using UnityEngine;

public class BaseAttribute
{
    public int curHealth { get; private set; }
    public int maxHealth { get; private set; }
    public int attack { get; private set; }
    public int defend { get; private set; }
    public int speed { get; private set; }
    public int attackInterval { get; private set; }
    public int attackRange { get; private set; }
    public string prefabName { get; private set; }
    public GameObject go { get; set; }
    public virtual void Init(BaseAttribute ba, int id)
    {
        var cfg = Config.Instance.GetConfig("fighter", id);
        ba.curHealth = Convert.ToInt32(cfg["maxHealth"]);
        ba.maxHealth = Convert.ToInt32(cfg["maxHealth"]);
        ba.attack = Convert.ToInt32(cfg["attack"]);
        ba.defend = Convert.ToInt32(cfg["defend"]);
        ba.speed = Convert.ToInt32(cfg["speed"]);
        ba.attackInterval = Convert.ToInt32(cfg["attackInterval"]);
        ba.attackRange = Convert.ToInt32(cfg["attackRange"]);
        ba.prefabName = cfg["prefabName"];
    }
    public BaseAttribute data { get; private set; }

    public virtual void Dead()
    {

    }
    public virtual void AddBlood(int add)
    {
        curHealth += add;
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
    }

    public virtual void Attack(BaseAttribute target)
    {
        
    }
}
