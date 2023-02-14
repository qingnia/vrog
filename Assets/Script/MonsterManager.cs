using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEditor.AI;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class MonsterManager : MonoBehaviour
{
    public Object[] monsterTemplate;
    public int monsterLimieNum = 0;
    private Dictionary<int, GameObject> monsters = new Dictionary<int, GameObject>();
    private int initNum = 0;
    private NavMeshSurface navMeshSurface;

    private void Awake()
    {
        navMeshSurface= GetComponent<NavMeshSurface>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        navMeshSurface.BuildNavMesh();
        if (initNum < monsterLimieNum)
        {
            int index = Random.Range(0, monsterTemplate.Length);
            GameObject go = Instantiate(monsterTemplate[index]) as GameObject;
            go.transform.SetParent(this.gameObject.transform, false);
            //var pos = Vector3.zero; 
            //pos.y = 2;
            //pos.x = pos.x + Random.Range(-8, 9);
            //pos.z = pos.z + Random.Range(-8, 9);
            //Debug.LogFormat("create enemy, index; {0}, pos: {1}", index, pos.ToString());
            //go.transform.position = pos;
            initNum++;
        }
    }
}
