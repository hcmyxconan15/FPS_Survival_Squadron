using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventSoundZombie : MonoBehaviour
{
    public string attack, death;

    //public void Idle()
    //{
    //    if(idle != null)
    //    {
    //        AudioManager.Instance.PlaySoundEffect(idle);
    //    }
    //}

    //public void Walk()
    //{
    //    if(walk != null)
    //    {
    //        AudioManager.Instance.PlaySoundEffect(walk);
    //    }
    //}

    //public void Run()
    //{
    //    if (run != null)
    //    {
    //        AudioManager.Instance.PlaySoundEffect(run);
    //    }
    //}

    public void Attack()
    {
        if (attack != null)
        {
            AudioManager.Instance.PlaySoundEffect(attack);
        }
    }

    public void Death()
    {
        if (attack != null)
        {
            AudioManager.Instance.PlaySoundEffect(death);
        }
    }
}
