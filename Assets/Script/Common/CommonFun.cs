using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditorInternal;

public class CommonFun
{
    public static List<int> String2IntList(string src, char split)
    {
        string[] str_array = src.Split('|');
        List<int> ret = new List<int>();
        foreach (var item in str_array)
        {
            ret.Add(int.Parse(item));
        }
        return ret;
    }

    public static void PrintMap(Dictionary<string, string> map)
    {
        foreach (string key in map.Keys)
        {
            Debug.LogFormat("key: {0}  value:{1}", key, map[key]);
        }
    }

    public static Vector3 getFrontPos(string dir, Vector3 pos)
    {
        Vector3 ret = new Vector3();
        switch (dir)
        {
            case "forward":
                ret.x = pos.x - 20;
                ret.y = pos.y;
                ret.z = pos.z;
                break;
            case "left":
                ret.x = pos.x;
                ret.y = pos.y;
                ret.z = pos.z - 20;
                break;
            case "right":
                ret.x = pos.x;
                ret.y = pos.y;
                ret.z = pos.z + 20;
                break;
            case "behind":
                ret.x = pos.x + 20;
                ret.y = pos.y;
                ret.z = pos.z;
                break;
            default: return ret;
        }
        return ret;
    }
}