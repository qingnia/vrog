using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject wall;
    public GameObject trigger;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void HideWall(bool hide)
    {
        if (hide)
        {
            wall.SetActive(false);
            trigger.SetActive(true);
        }
        else
        {
            wall.SetActive(true);
            trigger.SetActive(false);
        }
    }
}
