using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int maxHeath = 100;
    private Animator _animator;
    public int currentHeath;

    private static readonly int IsDie = Animator.StringToHash("isDie");
    private static readonly int IsHit = Animator.StringToHash("isHit");

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>(); 
        _animator.SetBool(IsDie,false);
        currentHeath = maxHeath;

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
        _animator.SetBool(IsDie,true);
        this.gameObject.SetActive(false);
    }
}
