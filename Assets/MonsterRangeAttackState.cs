using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterRangeAttackState : StateMachineBehaviour
{
    private EnemyManager _rangeAttack;
    Transform player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rangeAttack = animator.GetComponent<EnemyManager>();
        player = GameObject.FindGameObjectWithTag("player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < 4)
        {
            animator.SetBool("isMeleeAttacking", true);
            animator.SetBool("isRangeAttacking", false);
            animator.SetBool("isChasing", false);
        }
        if (_rangeAttack.rangedCounter == 5)
        {
            _rangeAttack.rangedCounter = 0;
            animator.SetBool("isRangeAttacking", false);
            animator.SetBool("isSpellAttacking", true);
        }
    }
    
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
