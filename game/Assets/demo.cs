using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demo : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("lockVelocity",true);
    }

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    //OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {          
        animator.SetBool("isRun",false);
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("isAttack2");
            animator.Play("attack_2");
        }
    }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("lockVelocity",false);
    }

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMachineEnter is called when entering a state machine via its Entry Node

    // OnStateMachineExit is called when exiting a state machine via its Exit Node

}
