using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public EnemyTemplate enemy_Template;
    //public Text name;

    SpriteRenderer sprite;
    public Animator _animator;
    public int attackDamge;
    public int currentHeath;

    public float time = 0.75f;
    
    private static readonly int IsDie = Animator.StringToHash("isDie");
    private static readonly int IsHit = Animator.StringToHash("isHit");

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        _animator.runtimeAnimatorController = enemy_Template.animator;
        sprite.sprite = enemy_Template.sprite;
        currentHeath = enemy_Template.maxHeath;
        attackDamge = enemy_Template.attackDamge;
    }

    // Update is called once per frame
    public void TakeDamge(int damge)
    {
        Debug.Log("hello");
        currentHeath -= damge;
        _animator.SetTrigger(IsHit);
        if (currentHeath <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        _animator.Play("Death");
        StartCoroutine(setTimeSetActive(time));

    }
    
    private IEnumerator setTimeSetActive(float timer)
    {  
        Debug.Log(timer);
        //Wait for 14 secs.
        yield return new WaitForSeconds(time);
        //Turn My game object that is set to false(off) to True(on).
        this.gameObject.SetActive(false);
    }
}