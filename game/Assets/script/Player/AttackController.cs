using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Transform hitBox;
    public float attackRange = 0.35f;
    public LayerMask enemyLayer;

    private Animator _animator;
    private static readonly int IsAttack = Animator.StringToHash("isAttack");


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _animator.SetTrigger(IsAttack);
            Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(hitBox.position, 
                attackRange, enemyLayer);
            foreach (Collider2D enemy in hitEnemys)
            {
                Debug.Log("trung quai");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(hitBox.position, attackRange);
    }
}