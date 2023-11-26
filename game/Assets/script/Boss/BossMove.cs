using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : StateMachineBehaviour
{

    public float speed = 2.5f;
    public float attackRange = 2.4f;
    Transform player;
    Rigidbody2D rb;
    //BossManager boss;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        //boss = animator.GetComponent<BossManager>();

    }   

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        flip();
        if (Vector2.Distance(player.position, rb.position) <= attackRange){
            animator.SetTrigger("Attack");
        }
        if (BossManager.instance.attackCount == 2 && animator.GetBool("isCoolDown")== false)
        {
            animator.SetBool("castSpell",true);
            BossManager.instance.attackCount = 0;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
 
    }
    
    void flip()
    {
        if (player.position.x > rb.position.x)
        {   
            rb.transform.localScale = new Vector3(1f, 1, 1);
        }
        else if (player.position.x < rb.position.x)
        {
            rb.transform.localScale = new Vector3(-1f, 1, 1);

        }
    }
}