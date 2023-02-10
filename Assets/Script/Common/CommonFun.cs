using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditorInternal;

public class CommonFun : MonoBehaviour
{

    public static Vector3 MapIndex2Vector(int x, int y, int floor)
    {
        Vector3 vec = new Vector3(x * 10, floor * 5, y * 10);
        return vec;
    }

    public static Vector3 Vector2MapIndex(Vector3 vec)
    {
        Vector3 ret = new Vector3(Mathf.Floor(vec.x / 10), Mathf.Floor(vec.y / 5), Mathf.Floor(vec.z / 10));
        return ret;
    }

    public static Vector3 Vector2RoomPos(Vector3 vec)
    {
        Vector3 ret = new Vector3(Mathf.Floor(vec.x / 10) * 10, Mathf.Floor(vec.y / 5) * 5, Mathf.Floor(vec.z / 10) * 10);
        return ret;
    }

    public static Vector3 NextPos(Vector3 vec, Direction dir)
    {
        Vector3 ret = vec;
        switch (dir)
        {
            case Direction.dirUp:
                vec.z += 10;
                break;
            case Direction.dirDown:
                vec.z -= 10;
                break;
            case Direction.dirLeft:
                vec.x -= 10;
                break;
            case Direction.dirRight:
                vec.x += 10;
                break;
            case Direction.dirStop:
                break;
        }
        return vec;
    }

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