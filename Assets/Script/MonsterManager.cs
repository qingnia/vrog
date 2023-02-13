using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

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

    private void RegenerateNavMesh()
    {
        navMeshSurface.BuildNavMesh();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (initNum < monsterLimieNum)
        {
            int index = Random.Range(0, monsterTemplate.Length);
            GameObject go = Instantiate(monsterTemplate[index]) as GameObject;
            go.transform.SetParent(this.gameObject.transform, false);
            var pos = transform.position;
            pos.x = pos.x + Random.Range(-9, 9);
            pos.z = pos.z + Random.Range(-9,-9);
            go.transform.position = pos;
            initNum++;
        }
    }
}
