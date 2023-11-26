using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour, IDamageable, IHeathSystemUi
{
    public static PlayerManager instance;
    public int maxHeath = 100;
    public int currentHeath;
    public int attack;
    [SerializeField]public static bool isDie;
    public static float time;
    public static float player_score;
    private Animator _animator;
    public Image heathBar;
    private Rigidbody2D _rigidbody2D;
    private void Awake()
    {
        instance = this;
        currentHeath = maxHeath;

    }
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        attack = GetComponent<PlayerAttack>().attackDamge;
        heathBar = GameObject.Find("HeathBarPlayer").GetComponent<Image>();
        isDie = false;
        time = 0;
        player_score = 0;
        displayHeath();
    }

    #region damage and display heath methods

    public void Damage(int damage = 0)
    {
        currentHeath -= damage;
        displayHeath();
        if (currentHeath > 0)
        {
            _animator.SetTrigger("isHurt");
            return;
        }

        Die();
    }

    public void displayHeath()
    {
        float heathRatio = (float)currentHeath / (float)maxHeath;
        heathBar.fillAmount = Mathf.Clamp(heathRatio, 0f, 1f);
    }
    public int getDamage()
    {
        return attack;
    }

    #endregion

    void Die()
    {
        isDie = true;
        _rigidbody2D.simulated = false;
        _animator.Play("Death");
    }

    public void LoadData()
    {
        PlayerData data = LoadSystem.LoadPlayer();
        if (data == null) return;
        currentHeath = data.heath;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Trap") || other.gameObject.CompareTag("Water"))
        {
            Die();
        }
    }
}