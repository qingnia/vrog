using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private Object roomObj;
    // Start is called before the first frame update
    void Start()
    {
        roomObj = Resources.Load("Room");
        CreateRoom(ROOM_TYPE.TURN, Vector3.zero, 0);
    }

    public void CreateRoom(ROOM_TYPE roomType, Vector3 pos, float yaw)
    {
        Quaternion rotation = Quaternion.Euler(0, yaw, 0);
        GameObject go = Instantiate(roomObj, pos, rotation) as GameObject;
        go.GetComponent<BaseRoom>().Init(roomType);
    }

    public void EnterRoom(GameObject go)
    {

    }
    public bool isMainPlayer(GameObject go)
    {
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
