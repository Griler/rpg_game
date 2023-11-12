using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class EnemyData
{
    public int heath;
    public float[] position;
    public float scaleX;
    public float[] patrolPointOne;
    public float[] patrolPointTwo;

    public EnemyData(EnemyManager enemyManager, EnemyPatrolling enemyPatrolling)
    {
        scaleX = enemyManager.transform.localScale.x;
        heath = enemyManager.currentHeath;
        position = new float[]
        {
            enemyManager.transform.position.x,
            enemyManager.transform.position.y,
            enemyManager.transform.position.z
        };
        patrolPointOne = new float[]
        {
            enemyPatrolling.patrolPoints[0].x,
            enemyPatrolling.patrolPoints[0].y,
            enemyPatrolling.patrolPoints[0].z
        };
        patrolPointTwo = new float[]
        {
            enemyPatrolling.patrolPoints[1].x,
            enemyPatrolling.patrolPoints[1].y,
            enemyPatrolling.patrolPoints[1].z
        };
    }
}