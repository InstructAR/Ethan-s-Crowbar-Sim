using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{

    //https://www.youtube.com/watch?v=9pVdiBogmew is teleportation script

    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerVal = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerVal);

        float gripVal = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripVal);
    }
}
