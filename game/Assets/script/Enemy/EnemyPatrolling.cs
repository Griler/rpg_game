using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyPatrolling : MonoBehaviour
{
    public Vector3[] patrolPoints;
    private Rigidbody2D _rigidbody2D;
    public float speedMove;
    public int patrolPointCurrent;
    private Animator _animator;

    private bool isTakeDamge = false;
    public Vector2 boxSize = new Vector2(0.4f, 0.55f);

    public EnemyMovement enemyMovement;

    public float timer = 0.5f;
    private float checkTimer = 0;
    bool onetime = true;
    private static readonly int IsHurt = Animator.StringToHash("isHurt");

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        speedMove = GetComponent<EnemyManager>().enemy_Template.speed;
        patrolPointCurrent = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<EnemyManager>().isGround())
        {
            if (onetime)
            {
                _animator.SetBool("isWalk", true);
                inputArryPoint();
                onetime = false;
            }

            if (isTakeDamge && checkTimer <= timer)
            {
                movePatrol();
                Debug.Log("hit");
                checkTimer += Time.deltaTime;
            }
            else
            {
                _animator.SetBool("isWalk", true);
                movePatrol(speedMove);
                isTakeDamge = false;
            }
        }
    }

    void movePatrol(float speed = 0)
    {
        changePatrolPoint();

        if (patrolPointCurrent == 0)
        {
            enemyMovement.Move(-1);
            if (Vector2.Distance(transform.position, patrolPoints[patrolPointCurrent]) < 0.2f)
            {
                patrolPointCurrent = 1;
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        if (patrolPointCurrent == 1)
        {
            enemyMovement.Move();
            if (Vector2.Distance(transform.position, patrolPoints[patrolPointCurrent]) < 0.2f)
            {
                transform.localScale = new Vector3(1, 1, 1);
                patrolPointCurrent = 0;
            }
        }
    }

    void inputArryPoint()
    {
        patrolPoints[0] = transform.position + Vector3.left * 1.45f;
        patrolPoints[1] = transform.position + Vector3.right * 1.45f;
    }

    void changePatrolPoint()
    {
        if (transform.localScale.x == 1) patrolPointCurrent = 0;
        if (transform.localScale.x == -1) patrolPointCurrent = 1;
    }

    public void isHurt(bool hit = false)
    {
        if (hit)
        {
            isTakeDamge = true;
            return;
        }

        isTakeDamge = false;
    }
}