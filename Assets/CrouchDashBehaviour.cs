using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchDashBehaviour : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var collider = animator.GetComponent<BoxCollider2D>();
        collider.size   = new Vector2(0.79f, 0.5672076f);
        collider.offset = new Vector2(-0.07f, -0.6738962f);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var collider = animator.GetComponent<BoxCollider2D>();
        collider.size   = new Vector2(0.79f, 1.685f);
        collider.offset = new Vector2(-0.07f, -0.115f);
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