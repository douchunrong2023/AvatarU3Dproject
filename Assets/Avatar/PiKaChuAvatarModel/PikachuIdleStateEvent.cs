using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

public class PikachuIdleStateEvent : StateMachineBehaviour
{
    [SerializeField] private GameObject avatar;

    [Header("Animation Loops")]
    [SerializeField] private float loopsTillScratch = 1f;
    [SerializeField] private float loopsTillYawn = 2f;
    [SerializeField] private float loopsTillSleep = 2f;

    // private bool idling;
    private System.Random random = new System.Random();

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("AnimDebug - PikachuIdleStateEvent entered");
        // idling = false;
        animator.SetBool("LeftIdle", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        // Debug.Log("AnimDebug - leftIdle: " + idling);
        // Debug.Log("AnimDebug - Scratched: " + animator.GetBool("Scratched"));
        // Debug.Log("AnimDebug - Yawned: " + animator.GetBool("Yawned"));
        // Transitions from idle to scratched, yawn and sleep based on how long the idle animation has been playing
        // Bools are set in the animator states
        // if (stateInfo.normalizedTime >= 1f)
        // {
        //     Debug.Log("AnimDebug - PikachuIdleStateEvent normalizedTime: " + stateInfo.normalizedTime);
        // }
        if (stateInfo.normalizedTime >= loopsTillScratch && !animator.GetBool("LeftIdle") && !animator.GetBool("Scratched"))
        {
            Debug.Log("AnimDebug - PikachuIdleStateEvent scratch");
            // idling = true;
            animator.SetBool("LeftIdle", true);
            int scratchAnim = random.Next(0, 2);
            if (scratchAnim == 0)
            {
                animator.SetTrigger("Scratch");
            }
            else
            {
                animator.SetTrigger("Scratch2");
            }
            return;
        }
        else if (stateInfo.normalizedTime >= loopsTillYawn && !animator.GetBool("LeftIdle") && !animator.GetBool("Yawned") && animator.GetBool("Scratched"))
        {
            Debug.Log("AnimDebug - PikachuIdleStateEvent yawn");
            // idling = true;
            animator.SetBool("LeftIdle", true); ;
            animator.SetTrigger("Yawn");
        }
        else if (stateInfo.normalizedTime >= loopsTillSleep && !animator.GetBool("LeftIdle") && animator.GetBool("Yawned") && animator.GetBool("Scratched"))
        {
            Debug.Log("AnimDebug - PikachuIdleStateEvent sleep");
            // idling = true;
            animator.SetBool("LeftIdle", true);
            animator.SetTrigger("Sleep");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("LeftIdle", true);
    }
}
