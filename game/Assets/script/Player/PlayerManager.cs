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
        attack = GetComponent<AttackController>().attackDamge;
        isDie = false;
    }

    public void Damage(int damage = 0)
    {
        currentHeath -= damage;
        displayHeath();
        if (currentHeath > 0)
        {   
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
        _animator.Play("Death");
    }
    // Update is called once per frame
}
