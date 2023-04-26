using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class AutomaticPitcher : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public Transform launchTube;
    public GameObject ballPrefab, lastBall, target;
    public float ballSpeed = 5.0f;
    
    void Start()
    {
        LaunchBall();
    }

    private void Update()
    {
        launchTube.LookAt(target.transform.position);
        float triggerVal = pinchAnimationAction.action.ReadValue<float>();
        if(triggerVal > 0.5)
        {
            LaunchBall();
        }
    }
    void LaunchBall()
    {
        lastBall = Instantiate(ballPrefab, launchTube.transform.position, Quaternion.identity, transform);
        lastBall.GetComponent<Rigidbody>().velocity = launchTube.forward * ballSpeed;
    }
}
