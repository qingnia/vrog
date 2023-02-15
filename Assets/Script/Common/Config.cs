using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class ConfigData
{
    public string key;
    public TextAsset textAsset;
    Dictionary<string, DATA_TYPE> dataTypes;
}

public class Config : MonoBehaviour
{
    public ConfigData[] configDatas = null;
    public static Config Instance { get; private set; }
    public static void Bind(GameObject go)
    {
        Instance = go.GetComponent<Config>();
    }

    public Dictionary<string, Dictionary<int, Dictionary<string, string>>> configs = new Dictionary<string, Dictionary<int, Dictionary<string, string>>>();

    public Dictionary<string, string> GetConfig(string key, int id)
    {
        if (!configs.ContainsKey(key))
        {
            TextAsset textAsset = null;
            foreach (var config in configDatas)
            {
                if (config.key == key)
                {
                    textAsset = config.textAsset;
                    break;
                }
            }
            if (textAsset == null)
            {
                Debug.LogErrorFormat("can't find config asset, key: {0}", key);
                return null;
            }
            configs[key] = LoadCsvData(textAsset);
        }
        var cfg = configs[key];
        if (!cfg.ContainsKey(id))
        {
            Debug.LogErrorFormat("no cfg, key:{0}, id: {1}", key, id);
            return new Dictionary<string, string>();
        }
        return cfg[id];
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
            lineArray[i] = lineArray[i].Substring(0, lineArray[i].Length - 1);
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
        for (int i = 2; i < lineArray.Length - 1; i++)
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