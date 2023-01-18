using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    private Collider2D range;
    private Transform rangeT;
    
    // Start is called before the first frame update
    void Start()
    {
        range = gameObject.GetComponentInChildren<Collider2D>();
        Debug.Log(range.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("COLLISION");
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy is here");
        }
    }
}
