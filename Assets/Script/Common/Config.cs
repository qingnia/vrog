﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    private Dictionary<int, Dictionary<string, string>> roomConfig = new Dictionary<int, Dictionary<string, string>>();
    private Dictionary<int, Dictionary<string, string>> playerConfig = new Dictionary<int, Dictionary<string, string>>();
    private Dictionary<int, Dictionary<string, string>> resConfig = new Dictionary<int, Dictionary<string, string>>();

    public TextAsset player;
    public TextAsset room;
    public TextAsset res;

    public Dictionary<string, string> GetRoomConfig(int roomID)
    {
        if (roomConfig.Count == 0)
        {
            //TextAsset binAsset = Resources.Load("Tables/Room", typeof(TextAsset)) as TextAsset;
            //roomConfig = LoadCsvData(binAsset);
            roomConfig = LoadCsvData(room);
        }
        if (!roomConfig.ContainsKey(roomID))
        {
            Debug.LogErrorFormat("no room cfg, roomID:{0}", roomID);
            return new Dictionary<string, string>();
        }
        return roomConfig[roomID];
    }

    public Dictionary<string, string> GetPlayerConfig(int playerID)
    {
        if (playerConfig.Count == 0)
        {
            playerConfig = LoadCsvData(player);
        }
        return playerConfig[playerID];
    }

    public Dictionary<string, string> GetResConfig(int resID)
    {
        if (resConfig.Count == 0)
        {
            resConfig = LoadCsvData(res);
        }
        return resConfig[resID];
    }

    private Dictionary<int, Dictionary<string, string>> LoadCsvData(TextAsset ta)
    {
        Dictionary<int, Dictionary<string, string>> csvInfo = new Dictionary<int, Dictionary<string, string>>();

        //读取每一行的内容  
        string[] lineArray = ta.text.Split('\n');
        for (int i = 0; i < lineArray.Length; i++)
        {
            if (lineArray[i].Length <= 1)
            {
                break;
            }
            //lineArray[i] = lineArray[i].Substring(0, lineArray[i].Length - 1);
        }

        //记录每行记录中的各字段内容
        string[] aryLine = null;

        //首行忽略

        //第二行是字段名
        string[] columnName = lineArray[1].Split('\t');
        //标示列数
        int columnCount = columnName.Length;

        int id = 0;
        //逐行读取CSV中的数据
        for (int i = 2; i < lineArray.Length - 2; i++)
        {
            //strLine = Common.ConvertStringUTF8(strLine, encoding);
            //strLine = Common.ConvertStringUTF8(strLine);

            aryLine = lineArray[i].Split('\t');
            id = int.Parse(aryLine[0]);
            if (!csvInfo.ContainsKey(id))
            {
                csvInfo[id] = new Dictionary<string, string>(100);
            }
            for (int j = 0; j < columnCount; j++)
            {
                string column = columnName[j];
                csvInfo[id][column] = aryLine[j];
            }
        }
        return csvInfo;
    }
}