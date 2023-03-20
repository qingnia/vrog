using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public TextMeshProUGUI infoName, infoNum;
    public string key = "aaa";
    public int value = 5;
    // Start is called before the first frame update
    void Start()
    {
        infoName.text = key;
        infoNum.text = value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
