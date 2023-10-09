using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
    public Vector3[] patrolPoints;
    private Rigidbody2D _rigidbody2D;
    public float speed;
    public int patrolPointCurrent;
    private Animator _animator;

    public Vector2 boxSize = new Vector2(0.4f, 0.55f);

    public LayerMask playerLayer;

    bool onetime = true;
    private static readonly int IsHurt = Animator.StringToHash("isHurt");

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        speed = GetComponent<EnemyManager>().enemy_Template.speed;
        Debug.Log(playerLayer.value);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<EnemyManager>().isGround())
        {
            if (onetime)
            {
                inputArryPoint();
                onetime = false;
                _animator.Play("Walk");
            }

            if (isHurt())
            {
                Debug.Log("trung quái");
                movePatrol();
            }
        }
    }

    void movePatrol()
    {
        if (patrolPointCurrent == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                patrolPoints[patrolPointCurrent], speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[patrolPointCurrent]) < 0.2f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                patrolPointCurrent = 1;
            }
        }

        if (patrolPointCurrent == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                patrolPoints[patrolPointCurrent], speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[patrolPointCurrent]) < 0.2f)
            {
                transform.localScale = new Vector3(1, 1, 1);
                patrolPointCurrent = 0;
            }
        }
    }

    void inputArryPoint()
    {
        patrolPoints[0] = transform.position + Vector3.left * 1.25f;
        patrolPoints[1] = transform.position + Vector3.right * 1.25f;
    }

    public bool isHurt(bool isHurt = false)
    {
        if (isHurt)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}