﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterRotator : MonoBehaviour
{
   private enum RotateState {
       Idle, Vertical, Horizontal, Ready
   }

   private RotateState state = RotateState.Idle;
   public float verticalRotateSpeed = 360f;
   public float horizontalRotateSpeed = 360f;

   void Update()
   {
       switch(state)
       {
           case RotateState.Idle:
                if(Input.GetButtonDown("Fire1"))
                {
                    state = RotateState.Horizontal;
                    Debug.Log(state);

                }
           break;
           case RotateState.Horizontal:
                if(Input.GetButton("Fire1"))
                {
                    transform.Rotate(new Vector3(0, horizontalRotateSpeed * Time.deltaTime,0));
                }
                else if (Input.GetButtonUp("Fire1"))
                {
                    state = RotateState.Vertical;
                    Debug.Log(state);
                }
           break;
           case RotateState.Vertical:
                if(Input.GetButton("Fire1"))
                {
                    transform.Rotate(new Vector3(-verticalRotateSpeed*Time.deltaTime,0,0));
                }
                else if(Input.GetButtonUp("Fire1"))
                {
                    state = RotateState.Ready;
                    Debug.Log(state);
                }
           break;
           case RotateState.Ready:
           break;
       }
   }
}