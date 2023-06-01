using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class TriggerAreaCheck : MonoBehaviour
{
    private EnemyBehaviour enemyParent;
    private void Awake()
    {
        enemyParent = GetComponentInParent<EnemyBehaviour>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            gameObject.SetActive(false);
            enemyParent.target = collision.transform;
            enemyParent.inRange = true;
            enemyParent.hotZone.SetActive(true);
        }
    }
}
