using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class BuffAsset : PlayableAsset
{
    public int addAttack = 0;
    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        var playable = ScriptPlayable<BuffBehaviour>.Create(graph);
        var bv = playable.GetBehaviour();
        if (bv != null)
        {
            bv.addAttack = addAttack;
            bv.go = go;
        }
        return playable;
    }
}
