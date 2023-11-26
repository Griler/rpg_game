using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BossManager : MonoBehaviour, IDamageable, IHeathSystemUi
{ 
    public EnemyTemplate bossTemplate;
    public Image heathBar;
    public float attackCount = 0;
    public GameObject[] spellList;
    //public Text name;

    #region Status Enemy

    SpriteRenderer sprite;
    public Animator _animator;
    public int attackDamge;
    public int currentHeath;
    private bool isDie = false;
    private Rigidbody2D _rigidbody2D;
    public static BossManager instance;
    #endregion

    #region stringAnimator

    private static readonly int IsHurt = Animator.StringToHash("isHurt");

    #endregion

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        _animator.runtimeAnimatorController = bossTemplate.animator;
        sprite.sprite = bossTemplate.sprite;
        currentHeath = bossTemplate.maxHeath;
        attackDamge = bossTemplate.attackDamge;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Damage(int damage)
    {
        currentHeath -= damage;
        displayHeath();
        if (currentHeath > 0)
        {
            _animator.SetTrigger("isHurt");
            isDie = true;
            return;
        }
        Die();
    }

    public void displayHeath()
    {
        float heathRatio = (float)currentHeath / (float)bossTemplate.maxHeath;
        heathBar.fillAmount = Mathf.Clamp(heathRatio, 0f, 1f);
    }

    public int getDamage()
    {
        return attackDamge;
    }

    void Die()
    {
        isDie = true;
        _rigidbody2D.simulated = false;
        _animator.SetBool("isDie",true);
        _animator.Play("deathBoss");
    }

    void destroyObject()
    {
        this.gameObject.SetActive(false);
        GameObject.Find("EndPoint").transform.GetChild(0).gameObject.SetActive(true);
    }

    public Transform player;

    public float checkTimer = 0;
    private bool isCooldown = true;
    public float coolDownTime = 3f;

    private void Update()
    {
        if (isCooldown)
        {
            checkTimer += Time.deltaTime;
            if (checkTimer >= coolDownTime)
            {
                checkTimer = 0f;
                isCooldown = false;
                _animator.SetBool("isCoolDown", false);
            }
        }
        _animator.SetFloat("countAttack", attackCount);
        castSkill();
    }

    void Attack()
    {
        attackCount += 1;
        _animator.SetBool("isCoolDown", true);
        isCooldown = true;
    }

    void castSkill()
    {
    }
    public GameObject spell;
    public float castSpellCheck = 0;
    void castSpell(){
        if(castSpellCheck==0){
            castSpellCheck++;
            foreach (var o in spellList)
            {
                Instantiate(spell, o.transform.position, transform.rotation);
            }
        }
    }
}