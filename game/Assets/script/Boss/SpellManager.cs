using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpellManager : MonoBehaviour, IDamageable
{
    private float countSpell = 0;
    private GameObject boss;
    private void Awake()
    {
        boss = GameObject.Find("Boss");
    }

    void DestroyGameObject()
    {
        countSpell++;
        if (countSpell == 2)
        {
            {
                boss.GetComponent<BossManager>().attackCount = 0;
                boss.GetComponent<BossManager>().castSpellCheck = 0;
                boss.GetComponent<Animator>().SetBool("castSpell", false);
                Destroy(gameObject);
            }
        }
    }

    public void Damage(int damage = 0)
    {
        return;
    }

    public int getDamage()
    {
        return 5;
    }
}