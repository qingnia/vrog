using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct interactInfo
{

}

public class InteractTrigger : MonoBehaviour
{
    BaseRoom bm;
    // Start is called before the first frame update
    void Start()
    {
        bm = GetComponentInParent<BaseRoom>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (bm)
        {
            Debug.Log("on collision");
            bm.EnterRoom(other);
        }
        var MonsterManager = GetComponentInParent<MonsterManager>();
        if (MonsterManager != null)
        {
            MonsterManager.EnterRoom();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var MonsterManager = GetComponentInParent<MonsterManager>();
        if (MonsterManager != null)
        {
            MonsterManager.LeaveRoom();
        }
    }
}
