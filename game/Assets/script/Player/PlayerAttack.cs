using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 0.3f;
    public int attackDamge = 10;
    public LayerMask enemyLayer;
    private Animator _animator;
    private static readonly int IsAttack = Animator.StringToHash("isAttack");
    public float speedAttackTimeCheck = 0.5f;
    public float checkTimer = 0f;

    public bool isAttacking;

    public static PlayerAttack instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isDie)
        {
            if (Input.GetButtonDown("Fire1") && checkTimer >= speedAttackTimeCheck)
            {
                Attack();
                checkTimer = 0;
            }
            checkTimer += Time.deltaTime;
        }
    }

    void Attack()
    {
        isAttacking = true;
        _animator.SetTrigger(IsAttack);
    }
}