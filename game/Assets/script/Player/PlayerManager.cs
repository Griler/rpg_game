using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour,IDamageable,IHeathSystemUi
{
    public int maxHeath = 100;
    public int currentHeath;
    public int attack;
    public static bool isDie;
    private Animator _animator;
    public Image heathBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHeath = maxHeath;
        _animator = GetComponent<Animator>();
        attack = GetComponent<PlayerAttack>().attackDamge;
        isDie = false;
    }

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
        Debug.Log(Mathf.Clamp(heathRatio, 0f, 1f));
    }
    public int getDamage()
    {
        return attack;
    }
    
    
    void Die()
    {
        isDie = true;
        //_animator.SetBool("isDie",true);
        _animator.Play("Death");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Trap") || other.gameObject.CompareTag("Water"))
        {
            Die();
        }
    }
}
