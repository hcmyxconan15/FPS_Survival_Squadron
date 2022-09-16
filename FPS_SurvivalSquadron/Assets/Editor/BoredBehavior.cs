using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoredBehavior : StateMachineBehaviour
{

    [SerializeField]
    private float timeUnitilBored;
    [SerializeField]
    private int numberOfBoredAnimation;

    private bool isBored;
    private float idleTime;
    private int boredAnimation;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Reset();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isBored == false)
        {
            idleTime += Time.deltaTime;
            if (idleTime > timeUnitilBored && stateInfo.normalizedTime % 1 < 0.02f)
            {
                isBored = true;
                boredAnimation = Random.Range(1, numberOfBoredAnimation + 1);
                boredAnimation = boredAnimation * 2 - 1;
                animator.SetFloat("BoredAnimation", boredAnimation - 1);

            }
        }
        else if (stateInfo.normalizedTime % 1 > 0.98f)
        {
            Reset();

        }
        animator.SetFloat("BoredAnimation", boredAnimation, 0.2f, Time.deltaTime);
    }
    private void Reset()
    {
        if (isBored)
        {
            boredAnimation --;
        }

        isBored = false;
        idleTime = 0;
        
    }


}
