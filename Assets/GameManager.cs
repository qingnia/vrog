using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Config config;
    public int initRoomId;
    private Object roomObj;
    private bool init = false;
    // Start is called before the first frame update
    void Start()
    {
        roomObj = Resources.Load("Room");
    }

    // Update is called once per frame
    void Update()
    {
        if (!init)
        {
            CreateRoom(1, Vector3.zero, 0);
            init = true;
        }
    }

    public void CreateRoom(int roomId, Vector3 pos, float yaw)
    {
        Debug.LogFormat("create room, roomId:{0}", roomId.ToString());
        Quaternion rotation = Quaternion.Euler(0, yaw, 0);
        GameObject go = Instantiate(roomObj, pos, rotation) as GameObject;
        var cfg = config.GetRoomConfig(roomId);
        go.GetComponent<BaseRoom>().Init(cfg);
    }

    public void EnterRoom(GameObject go)
    {

    }
    public bool isMainPlayer(GameObject go)
    {
        return true;
    }
}
