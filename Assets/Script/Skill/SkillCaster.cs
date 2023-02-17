using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;

public class CastSkillData
{
    public int skillID;
    //技能的CD控制
    public long castTime;
    //可连续施放两次的技能，或者普攻二段处理
    public int castTimes;

    public CastSkillData(int id)
    {
        skillID = id;
        castTime = 0;
        castTimes = 0;
    }
    public void RecordCast()
    {
        castTime = DateUtil.ConvertTimeStampMilli(DateTime.Now);
        castTimes++;
    }
    public bool checkCD()
    {
        var cfg = Config.Instance.GetConfig("skill", skillID);
        int cd = int.Parse(cfg["cd"]);
        if (castTime + cd > DateUtil.ConvertTimeStampMilli(DateTime.Now))
        {
            Debug.LogWarningFormat("cast skill cd error, skill: {0}", skillID);
            return false;
        }
        return true;
    }
}

public class SkillCaster : MonoBehaviour
{
    [HideInInspector]
    public PlayableDirector pd;

    public Dictionary<int, CastSkillData> skillData;
    // Start is called before the first frame update
    void Start()
    {
        pd = GetComponent<PlayableDirector>();
        skillData= new Dictionary<int, CastSkillData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CastSkill(int skillID)
    {
        Debug.LogFormat("try cast skill, id:{0}", skillID);
        var cfg = Config.Instance.GetConfig("skill", skillID);
        if (!skillData.ContainsKey(skillID))
        {
            skillData.Add(skillID, new CastSkillData(skillID));
        }
        var data = skillData[skillID];
        //检查会有很多种条件，先做CD
        if (!data.checkCD())
        {
            return false;
        }
        //条件全部检查完，再标记施放
        data.RecordCast();
        if (cfg["timeLine"] != "")
        {
            var asset = Resources.Load(cfg["timeLine"]);
            if (asset != null)
            {
                Debug.LogFormat("start timeline, tl:{0}", cfg["timeLine"]);
                pd.playableAsset = Instantiate(asset) as PlayableAsset;
                pd.Play();
            }
        }
        return true;
    }
}
