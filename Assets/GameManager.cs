using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
    string[] wallKeys = new string[4];
    public GameObject player;
    public Config config;
    public int initRoomId;
    private Object roomObj;
    private bool init = false;
    // Start is called before the first frame update
    void Start()
    {
        wallKeys[0] = "forward";
        wallKeys[1] = "left";
        wallKeys[2] = "right";
        wallKeys[3] = "behind";
        roomObj = Resources.Load("Room");
    }

    // Update is called once per frame
    void Update()
    {
        if (!init)
        {
            CreateRoom(ROOM_TYPE.READY, Vector3.zero);
            init = true;
        }
    }

    public void CreateRoom(ROOM_TYPE rt, Vector3 pos)
    {
        Debug.LogFormat("create room, room type:{0}", rt.ToString());
        GameObject go = Instantiate(roomObj, pos, Quaternion.identity) as GameObject;
        go.transform.SetParent(this.transform, false);
        Dictionary<string, int> wallInfo = new Dictionary<string, int>();
        foreach(string key in wallKeys)
        {
            if (rt == ROOM_TYPE.READY)
            {
                if (key == "behind")
                {
                    wallInfo[key] = 0;
                }
                else
                {
                    wallInfo[key] = 1;
                }
            }
            else
            {
                wallInfo[key] = Random.Range(0, 1);
            }
        }
        //var cfg = config.GetRoomConfig(roomId);
        go.GetComponent<BaseRoom>().Init(wallInfo);
    }

    public void EnterRoom(GameObject go)
    {

    }
    public bool isMainPlayer(GameObject go)
    {
        return true;
    }
}
