﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoboldDashAttakBehaviour : StateMachineBehaviour
{
    Rigidbody2D rb;
    BasicEnemy enemy;
    KoboldAttack dashAttack;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<BasicEnemy>();
        dashAttack = animator.GetComponent<KoboldAttack>();
        dashAttack.EnableAttackCollider();
        dashAttack.DashAttack();
        rb.drag = dashAttack.attackDrag;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    enemy.LookAtPlayer();
    //}

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dashAttack.DisableAttackCollider();
        rb.drag = dashAttack.originalDrag;
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