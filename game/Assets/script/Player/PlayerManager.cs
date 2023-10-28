using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour,IDamageable
{
    public int maxHeath = 100;
    public int currentHeath;
    public int attack;

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHeath = maxHeath;
        _animator = GetComponent<Animator>();
        attack = GetComponent<AttackController>().attackDamge;
    }

    public void Damage(int damage = 0)
    {
        currentHeath -= damage;
        if (currentHeath > 0)
        {   
            return;
        }
        Die();
    }

    public int getDamage()
    {
        return attack;
    }
    void Die()
    {
        _animator.Play("Death");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
