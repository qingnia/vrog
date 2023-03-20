using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HandlerBase
{
    public GameObject from;
    public GameObject target;

    public virtual bool Excute()
    {
        return true;
    }
}
