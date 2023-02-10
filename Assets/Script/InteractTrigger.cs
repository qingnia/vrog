using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct interactInfo
{

}

public class InteractTrigger : MonoBehaviour
{
    BaseRoom bm;
    private bool isTriggerd;
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
        if (bm && !isTriggerd)
        {
            Debug.Log("on collision");
            bm.EnterRoom(other);
            isTriggerd = true;
        }
    }
}
