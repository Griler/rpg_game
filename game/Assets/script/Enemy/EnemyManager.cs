using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour, IDamageable, IHeathSystemUi
{
    public HitBoxArea _hitBoxArea;
    public EnemyTemplate enemy_Template;
    public Image heathBar;
    //public Text name;
    #region Status Enemy

    SpriteRenderer sprite;
    public Animator _animator;
    public int attackDamge;
    public int currentHeath;
    public float speed;
    public float time = 0.75f;
    private bool isDie = false;
    private Rigidbody2D _rigidbody2D;
    #endregion

    #region check ground varriable

    public float castDistane = 0.25f;
    public Vector2 boxSize = new Vector2(0.3f, 0.1f);
    public LayerMask groundLayer;
        
    #endregion

    #region stringAnimator

    private static readonly int IsDie = Animator.StringToHash("isDie");
    private static readonly int IsHurt = Animator.StringToHash("isHurt");
    private static readonly int IsWalk = Animator.StringToHash("isWalk");

    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        _animator.runtimeAnimatorController = enemy_Template.animator;
        sprite.sprite = enemy_Template.sprite;
        currentHeath = enemy_Template.maxHeath;
        attackDamge = enemy_Template.attackDamge;
        speed = enemy_Template.speed;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        SaveSytem.EnemyDatas.Add(this);
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (_hitBoxArea.targets.Count > 0)
        {
            _animator.SetBool("canAttack", true);
            _animator.SetBool("lockVelocity", true);
        }
        else
        {
            _animator.SetBool("canAttack", false);
        }
    }

    public void Damage(int damage)
    {
        currentHeath -= damage;
        displayHeath();
        if (currentHeath > 0)
        {
            _animator.SetTrigger(IsHurt);
            isDie = true;
            return;
        }

        Die();
    }

    public void displayHeath()
    {
        float heathRatio = (float)currentHeath / (float)enemy_Template.maxHeath;
        heathBar.fillAmount = Mathf.Clamp(heathRatio, 0f, 1f);
        Debug.Log(Mathf.Clamp(heathRatio, 0f, 1f));
    }

    public int getDamage()
    {
        return attackDamge;
    }

    void Die()
    {
        _rigidbody2D.simulated = false;
        PlayerManager.player_score++;
        _animator.SetBool(IsDie, true);
        _animator.Play("Enemy_Death");
        StartCoroutine(setTimeSetActiveFalse(time));
        SaveSytem.EnemyDatas.Remove(this);
    }

    public bool isGround()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up,
                castDistane, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator setTimeSetActiveFalse(float timer)
    {
        yield return new WaitForSeconds(timer);
        this.gameObject.SetActive(false);
    }
    
    
}