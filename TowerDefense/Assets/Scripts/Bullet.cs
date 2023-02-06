// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class Bullet : MonoBehaviour
// {
//     private Transform enemy;
//     private TowerSingle parentTower;
//     private TowerAttack range;
//     private Rigidbody2D rb;
//
//     // Start is called before the first frame update
//     void Start()
//     {
//         rb = gameObject.GetComponent<Rigidbody2D>();
//         parentTower = gameObject.GetComponentInParent<TowerSingle>();
//         range = parentTower.GetTowerRange();
//         
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         if (parentTower.GetEnemyTransform() != null)
//         {
//             enemy = parentTower.GetEnemyTransform();
//         
//             Vector3 direction = enemy.position - transform.position;
//             rb.velocity = new Vector2(direction.x, direction.y).normalized * 5f;
//
//             float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
//             transform.rotation = Quaternion.Euler(0,0,rotation);
//         }
//         
//     }
//
//     private void OnTriggerEnter2D(Collider2D col)
//     {
//         if (col.CompareTag("Enemy"))
//         {
//            // Debug.Log("enemy hit");
//             //col.GetComponentInParent<Enemy>().AttackEnemy(parentTower.GetDamage());
//             Destroy(gameObject);
//         }
//     }
// }