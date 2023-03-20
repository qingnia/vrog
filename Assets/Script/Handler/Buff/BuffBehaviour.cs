using NodeCanvas.BehaviourTrees;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class BuffBehaviour : PlayableBehaviour
{
    public int addAttack = 0;
    public GameObject go;
    // Called when the owning graph starts playing
    public override void OnGraphStart(Playable playable)
    {
        var fighter = go.GetComponent<Fighter>();
        fighter.baseAttribute.attack += addAttack;
    }

    // Called when the owning graph stops playing
    public override void OnGraphStop(Playable playable)
    {
        if (go)
        {
            var fighter = go.GetComponent<Fighter>();
            fighter.baseAttribute.attack -= addAttack;
        }
    }

    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        
    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        
    }

    // Called each frame while the state is set to Play
    public override void PrepareFrame(Playable playable, FrameData info)
    {
        
    }
}
