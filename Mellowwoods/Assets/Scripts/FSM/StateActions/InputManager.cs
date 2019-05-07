using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM{
    public class InputManager: StateAction{
        PlayerStateManager s;
        bool RB,LB, LT, RT,B,A,Y,X,inventory,leftArrow, rightArrow,upArrow,downArrow;
        bool isAttacking;
        public InputManager(PlayerStateManager states)
        {
            s = states;
        }
        public override bool Execute()
        {
            bool retVal = false;
            s.horizontal = Input.GetAxis("Horizontal");
            s.vertical = Input.GetAxis("Vertical");
            RB = Input.GetButton("RB");
            LB = Input.GetButton("LB");
            RT = Input.GetButton("RT");
            LT = Input.GetButton("LT");
            B = Input.GetButton("B");
            A = Input.GetButton("A");
            Y = Input.GetButton("Y");
            X = Input.GetButton("X");
            inventory = Input.GetButton("Inventory");
            leftArrow = Input.GetButton("Left Arrow");
            rightArrow = Input.GetButton("Right Arrow");
            downArrow = Input.GetButton("Down Arrow");
            upArrow = Input.GetButton("Up Arrow");
            s.mouseX = Input.GetAxis("Mouse X");
            s.mouseY = Input.GetAxis("Mouse Y");
            s.moveAmount = Mathf.Clamp01(Mathf.Abs(s.horizontal) + Mathf.Abs(s.vertical));

            retVal = IsAttacking();
            return retVal;

        }
        bool IsAttacking()
        {
            if(RB || LB || RT || LT)
            {   
                //isAttacking = true;
            }
            if(Y)
            {
                //isAttacking = false;
            }
            if(isAttacking)
            {   
                //s.PlayTargetAnimation("Eva_Attack1");
                //s.ChangeState(s.combatID);

            }
            return isAttacking;
        }

        
    }
}