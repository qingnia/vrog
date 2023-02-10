using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject wall;
    public GameObject trigger;
    public string dir;
    public DOOR_STATUS status
    { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void setDir(string dir)
    {
        this.dir = dir;
        Vector3 pos = transform.position;
        pos.y = 5;
        Vector3 scale = Vector3.one;
        scale.y = 10;
        switch (dir)
        {
            case "forward":
                pos.x -= 9.5f;
                scale.z = 20;
                break;
            case "left":
                pos.z -= 9.5f;
                scale.x = 20;
                break;
            case "right":
                pos.z += 9.5f;
                scale.x = 20;
                break;
            case "behind":
                pos.x += 9.5f;
                scale.z = 20;
                break;
            default: break;
        }
        transform.position = pos;
        transform.localScale = scale;
    }

    public void modifyStatus(DOOR_STATUS _status)
    {
        status = _status;
        switch(status)
        {
            case DOOR_STATUS.Close:
                wall.SetActive(true);
                break;
            case DOOR_STATUS.Uncheck:
                wall.SetActive(false);
                break;
            case DOOR_STATUS.Checked:
                wall.SetActive(false);
                break;
            default: break;
        }
    }

}
