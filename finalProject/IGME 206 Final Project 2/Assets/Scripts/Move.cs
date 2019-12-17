using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public Transform Enemy;
    float HP = 10;
    float MoveSpeed = 4;

    void Start()
    {
        Enemy = GameObject.FindWithTag("Tag2").transform;
    }

    void Update()
    {
        if(GameObject.FindWithTag("Tag2") != null)
{
        //Find and move towards enemy
        transform.LookAt(Enemy);
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        Enemy = GameObject.FindWithTag("Tag2").transform;
}
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Tag2")
        {
            HP -= Random.Range(1.0f, 3.0f);
Debug.Log(HP);
            if(HP<=0)
            {
                Destroy(gameObject);
            }

        }
    }
}