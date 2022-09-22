using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponAnimationEvent : MonoBehaviour
{
    public class AnimationEvent : UnityEvent<string>
    {

    }
    public AnimationEvent weaponAnimationEvent = new AnimationEvent();
    public void OnAnimationEvent(string evenName)
    {
        weaponAnimationEvent.Invoke(evenName);
    }
}
