﻿using UnityEngine;
using System.Collections;

public class OpenableDoorTemporary : MonoBehaviour
{
    [SerializeField]
    int
        triggerNumber = 1;
    [SerializeField]
    GameObject
        trigger1;
    [SerializeField]
    GameObject
        trigger2;
    [SerializeField]
    Vector2
        doorMove = new Vector2(1, 0);
	
    private bool _isOpened;
    private Vector3 originalPosition;
	Animator anim;
    // Use this for initialization
    void Start()
    {
		anim = GetComponent<Animator> ();
        originalPosition = this.transform.position;
    }
	
    // Update is called once per frame
    void FixedUpdate()
    {
        switch (triggerNumber)
        {
            case 1:
                if (trigger1.GetComponent<TriggerForDoorTemporary>().isTriggered)
                {
                    if (!_isOpened)
                    {
                        OpenDoor();
                    }
                } else
                {
                    CloseDoor();
                }
                break;
            case 2:
			if (trigger1.GetComponent<TriggerForDoorTemporary>().isTriggered || trigger2.GetComponent<TriggerForDoorTemporary>().isTriggered)
			{
				anim.SetBool ("HalfOpen", true);
			}
			else{
				anim.SetBool ("HalfOpen", false);
			}
                if (trigger1.GetComponent<TriggerForDoorTemporary>().isTriggered && trigger2.GetComponent<TriggerForDoorTemporary>().isTriggered)
                {
                    if (!_isOpened)
                    {
                        //Debug.Log ("weee");
                        OpenDoor();
                    }
                } else
                {
                    CloseDoor();
                }
                break;
            default:
                break;
        }
    }
    void OpenDoor()
    {
        Destroy(this.gameObject);
        switch (triggerNumber)
        {
            case 1:         
                Destroy(trigger1);
                break;
            case 2: 
                Destroy(trigger1);
                Destroy(trigger2);
                break;
            default:
                break;
        }
		
        _isOpened = true;
    }
    void CloseDoor()
    {
        this.transform.position = originalPosition;
		
        _isOpened = false;
    }
}
