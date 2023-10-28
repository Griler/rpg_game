using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public float attackRange = 0.3f;
    public int attackDamge = 10;
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
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    void Attack()
    {
        _animator.SetTrigger(IsAttack);
    }
}