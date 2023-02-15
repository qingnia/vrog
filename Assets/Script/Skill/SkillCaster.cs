using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;

public class SkillCaster : MonoBehaviour
{
    [HideInInspector]
    public PlayableDirector pd;
    // Start is called before the first frame update
    void Start()
    {
        pd = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CastSkill(int skillID)
    {
        Debug.LogFormat("try cast skill, id:{0}", skillID);
        var cfg = Config.Instance.GetConfig("skill", skillID);
        CommonFun.PrintMap(cfg);
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
    }
}
