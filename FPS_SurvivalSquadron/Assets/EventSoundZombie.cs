using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventSoundZombie : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Attack(string attack)
    {
        AudioManager.Instance.PlaySoundEffect(attack);
    }

    public void Run(string run)
    {
        AudioManager.Instance.PlaySoundEffect(run);
    }

    private void Update()
    {
        
    }

}
