using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType
{
    Bullet = 4,
    None = 8,
    Buff = 32,
}

public class SkillData
{
    [HideInInspector]
    public GameObject Owner;

    [SerializeField]
    public SkillData skill;

    public int level;

    [HideInInspector]
    public float coolRemain;

    [HideInInspector]
    public GameObject[] attackTargets;

    [HideInInspector]
    public GameObject skillPrefab;

    [HideInInspector]
    public GameObject hitFxPrefab;
}

[CreateAssetMenu(menuName ="Create SkillTemp")]
public class SkillTemp : ScriptableObject
{
    public DamageType[] damageType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
