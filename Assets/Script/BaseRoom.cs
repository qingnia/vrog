using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BaseRoom : MonoBehaviour
{
    public float rotationY;
    public Dictionary<string, Wall> walls = new Dictionary<string, Wall>();
    public string roomType;
    public GameObject player;
    public GameManager gm;
    private bool enterd = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Character");
        var go = GameObject.Find("GameManager");
        gm = go.GetComponent<GameManager>();
    }

    public void Init(Dictionary<string, int> wallInfo)
    {
        var wallObj = Resources.Load("wall");
        Debug.Log("init room");
        foreach (string key in wallInfo.Keys)
        {
            Debug.LogFormat("key: {0}  value:{1}", key, wallInfo[key]);
            GameObject go = Instantiate(wallObj) as GameObject;
            go.transform.SetParent(this.gameObject.transform, false);
            var wall = go.GetComponent<Wall>();
            if (wallInfo[key] == 1)
            {
                wall.modifyStatus(DOOR_STATUS.Uncheck);
            }
            else
            {
                wall.modifyStatus(DOOR_STATUS.Close);
            }
            walls.Add(key, go.GetComponent<Wall>());
        }
    }

    private void Update()
    {
    }


    public Vector3 getDoorPos()
    {
        return Vector3.zero;
    }

    public void EnterRoom(Collider collision)
    {
        Debug.Log("enter room, base room");
        if (collision.transform == player.transform)
        {
            if (!enterd)
            {
                //首次进入房间，把每个门外的屋子也生成好
                foreach (string key in walls.Keys)
                {
                    var wall = walls[key];
                    if (walls[key].status == DOOR_STATUS.Uncheck)
                    {
                        Vector3 pos = CommonFun.getFrontPos(key, transform.position);
                        //随机生成墙或门，避免旋转
                        gm.CreateRoom(ROOM_TYPE.FIGHT, pos);
                        walls[key].modifyStatus(DOOR_STATUS.Checked);
                    }
                }
                enterd = true;
            }
        }
    }

}
