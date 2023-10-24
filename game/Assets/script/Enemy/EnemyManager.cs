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
    public float speed;

    public float time = 0.75f;

    public float castDistane = 0.25f;
    public Vector2 boxSize = new Vector2(0.3f, 0.1f);
    public LayerMask groundLayer;

    private static readonly int IsDie = Animator.StringToHash("isDie");
    private static readonly int IsHurt = Animator.StringToHash("isHurt");
    private static readonly int IsWalk = Animator.StringToHash("isWalk");

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        _animator.runtimeAnimatorController = enemy_Template.animator;
        sprite.sprite = enemy_Template.sprite;
        currentHeath = enemy_Template.maxHeath;
        attackDamge = enemy_Template.attackDamge;
        speed = enemy_Template.speed;
    }

    // Update is called once per frame
    public void TakeDamge(int damge)
    {
        currentHeath -= damge;
        if (currentHeath > 0)
        {
            this.GetComponent<EnemyPatrolling>().isHurt(true);
            _animator.SetTrigger(IsHurt);
            _animator.SetBool(IsWalk,false);
            return;
        }
        Die();

    }

    void Die()
    {
        _animator.SetBool(IsDie, true);
        _animator.SetBool(IsWalk,false);
        StartCoroutine(setTimeSetActiveFalse(time));
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
        _animator.SetBool("isDie", false);
        //Turn My game object that is set to false(off) to True(on).
        this.gameObject.SetActive(false);
    }
}