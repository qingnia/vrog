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
    private Dictionary<string, string> keyFront = new Dictionary<string, string>();
    // Start is called before the first frame update
    void Start()
    {
        wallKeys[0] = "forward";
        wallKeys[1] = "left";
        wallKeys[2] = "right";
        wallKeys[3] = "behind";
        keyFront["forward"] = "behind";
        keyFront["behind"] = "forward";
        keyFront["left"] = "right";
        keyFront["right"] = "left";
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

    public void CreateRoom(ROOM_TYPE rt, Vector3 pos, string from = "behind")
    {
        Debug.LogFormat("create room, room type:{0}", rt.ToString());
        GameObject go = Instantiate(roomObj) as GameObject;
        go.transform.SetParent(this.transform, false);
        go.transform.localPosition = pos;
        Dictionary<string, DOOR_STATUS> wallInfo = new Dictionary<string, DOOR_STATUS>();
        foreach(string key in wallKeys)
        {
            if (rt == ROOM_TYPE.READY)
            {
                if (key == "behind")
                {
                    wallInfo[key] = DOOR_STATUS.Close;
                }
                else
                {
                    wallInfo[key] = DOOR_STATUS.Uncheck;
                }
            }
            else
            {
                if (key == keyFront[from])
                {
                    Debug.LogFormat("random wall, front, from:{0}, key:{1}", from, key);
                    wallInfo[key] = DOOR_STATUS.Checked;
                }
                else
                {
                    wallInfo[key] = (DOOR_STATUS)Random.Range(0, 2);
                }
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
