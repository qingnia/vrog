using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.AI.Navigation;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public int[] monsterConfigIds= null;
    public int monsterLimitNum = 0;
    private NavMeshSurface navMeshSurface;
    private BaseAttribute[] enemies = null;

    private void Awake()
    {
        navMeshSurface= GetComponent<NavMeshSurface>();
    }

    // Start is called before the first frame update
    void Start()
    {
        enemies = new BaseAttribute[monsterLimitNum];
        //创建房间后立即进行怪物的数据初始化
        for (int i = 0; i < monsterLimitNum; i++)
        {
            BaseAttribute ba = new BaseAttribute();
            int index = Random.Range(0, monsterConfigIds.Length);
            ba.Init(ba, monsterConfigIds[index]);
            enemies[i] = ba;
        }
    }

    // Update is called once per frame
    void Update()
    {
        navMeshSurface.BuildNavMesh();
    }

    public void EnterRoom()
    {
        //进入房间后根据怪物数据用池子创建怪物对象
        for (int i = 0; i < enemies.Length; i++)
        {
            var enemy = enemies[i];
            if (enemy.curHealth < 0)
                continue;
            var obj = Resources.Load(enemy.prefabName);
            PoolSystem.Instance.InitPool(obj, 5);
            var go = PoolSystem.Instance.GetInstance<GameObject>(obj);
            go.GetComponent<Fighter>().baseAttribute = enemy;
            go.transform.SetParent(this.gameObject.transform, false);
            enemy.go = go;
        }
    }
    public void LeaveRoom()
    {
        //离开房间后怪物对象放进对象池，保留数据
        //进入房间后根据怪物数据用池子创建怪物对象
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].go.SetActive(false);
            enemies[i].go = null;
        }
    }
}
