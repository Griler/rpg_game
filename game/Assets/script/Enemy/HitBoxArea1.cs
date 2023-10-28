using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxArea1 : MonoBehaviour
{
    public static bool check = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (EnemyPatrolling.patrolPointCurrent == 0)
            {
                EnemyPatrolling.patrolPointCurrent = 1;
            }
            else
            {
                EnemyPatrolling.patrolPointCurrent = 0;
            }

            this.transform.parent.localScale = new Vector3(transform.parent.localScale.x * -1f, 1, 1);
        }
    }
}