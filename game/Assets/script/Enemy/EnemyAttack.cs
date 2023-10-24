using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    #region Public Varribales

    public HitBoxArea _hitBoxArea;
    #endregion

    #region private Varriables
    private RaycastHit2D hit;
    private GameObject target;
    private Animator animator;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;
    #endregion
    // Start is called before the first frame update

    private void Awake()
    {
       
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_hitBoxArea.targets.Count > 0)
        {
            animator.SetBool("canAttack",true);
            animator.SetBool("lockVelocity",true);
        }
        else
        {
            animator.SetBool("canAttack",false);
            animator.SetBool("lockVelocity",false);

        }
    }
}
