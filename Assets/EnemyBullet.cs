using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Target
{

    private Vector3 targetPos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPos != Vector3.zero)
        {
            if ((transform.position - targetPos).magnitude <= 1)
            {
                targetPos = Vector3.zero;
                return;
            }
            Debug.LogFormat("update bullet pos, before: {0}", transform.position.ToString());
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 4 * Time.deltaTime);
            Debug.LogFormat("update bullet pos, after: {0}", transform.position.ToString());
        }
    }

    public void InitBullet(Vector3 orgPos, Vector3 targetPos)
    {
        transform.position = orgPos;
        this.targetPos = targetPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogFormat("bullet trigger player");
        Got(5);
    }
}
