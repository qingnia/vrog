using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject wall;
    public GameObject trigger;
    public DOOR_STATUS status
    { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
       
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
