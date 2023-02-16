using System;
using UnityEngine;

[Serializable]
public class BaseAttribute
{
    public int curHealth { get; set; }
    public int maxHealth { get; set; }
    public int attack;
    public int defend { get; set; }
    public int speed { get; set; }
    public int attackInterval { get; set; }
    public int attackRange { get; set; }
    public string prefabName { get; set; }
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

    public virtual void AddBlood(int add)
    {
        curHealth += add;
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
    }

}
