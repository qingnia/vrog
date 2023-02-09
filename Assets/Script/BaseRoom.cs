using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DOOR_STATUS
{
    Open,
    Close
}

public enum ROOM_TYPE
{
    SINGLE_DOOR,
    STRAIGHT,
    TURN,
    THREE_DOOR,
    FOUR_DOOR
}

public class BaseRoom : MonoBehaviour
{
    public Vector3 pos;
    public float rotationY;
    public Wall forward, left, right, behind;
    public ROOM_TYPE roomType;
    public GameObject player;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Character");
        var go = GameObject.Find("GameManager");
        gm = go.GetComponent<GameManager>();
    }

    public void Init(ROOM_TYPE _roomType)
    {
        roomType = _roomType;
        Debug.LogFormat("init room type", roomType.ToString());
        switch (roomType)
        {
            case ROOM_TYPE.SINGLE_DOOR:
                forward.HideWall(false);
                left.HideWall(false);
                right.HideWall(false);
                behind.HideWall(true);
                break;
            case ROOM_TYPE.STRAIGHT:
                forward.HideWall(true);
                left.HideWall(false);
                right.HideWall(false);
                behind.HideWall(true);
                break;
            case ROOM_TYPE.TURN:
                forward.HideWall(false);
                left.HideWall(false);
                right.HideWall(true);
                behind.HideWall(true);
                break;
            case ROOM_TYPE.THREE_DOOR:
                forward.HideWall(false);
                left.HideWall(true);
                right.HideWall(true);
                behind.HideWall(true);
                break;
            case ROOM_TYPE.FOUR_DOOR:
                forward.HideWall(true);
                left.HideWall(true);
                right.HideWall(true);
                behind.HideWall(true);
                break;
            default:
                break;
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

        }
    }

}
