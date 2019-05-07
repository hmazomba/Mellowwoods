using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM{
    //This action moves and animates the character. The movement is based on the look direction of a camera.
    public class CharacterMovement: StateAction{
        PlayerStateManager states;      

        public CharacterMovement(PlayerStateManager playerStateManager)
        {
            states = playerStateManager;
        }

         public override bool Execute()
        {
            float frontY = 0;
            RaycastHit hit;
            Vector3 origin = states.mTransform.position  + (states.mTransform.forward * states.frontRayOffset);
            origin.y += .5f;
            Debug.DrawRay(origin, -Vector3.up, Color.red, .01f, false);
            if(Physics.Raycast(origin, -Vector3.up, out hit, 1, states.ignoreForGroundCheck)){
                float y = hit.point.y;
                frontY = y - states.mTransform.position.y;
            }
            Vector3 currentVelocity = states.rigidbody.velocity;
            Vector3 targetVelocity = states.mTransform.forward * states.moveAmount * states.movementSpeed;

            if(states.isLockingOn)
            {
                targetVelocity = states.rotateDirection * states.moveAmount * states.movementSpeed;
            }

            if(states.isGrounded)
            {
                float moveAmount = states.moveAmount;

                if(moveAmount > 0.1f)
                {
                    states.rigidbody.isKinematic = false;
                    states.rigidbody.drag = 0;
                    if(Mathf.Abs(frontY) > 0.02f)
                    {
                        targetVelocity.y = ((frontY > 0) ? frontY + 0.2f: frontY - 0.2f)* states.movementSpeed;
                    }
                }
                else
                {
                    float abs = Mathf.Abs(frontY);
                    {
                        if(abs > 0.02f)
                        {
                            states.rigidbody.isKinematic = true;
                            targetVelocity.y = 0;
                            states.rigidbody.drag = 4;
                        }
                    }
                }
                HandleCamRotation();              
            }
            else 
            {
                states.rigidbody.isKinematic = false;
                states.rigidbody.drag = 0;
                targetVelocity.y = currentVelocity.y;
            }
            HandleAnimations();
            
            Debug.DrawRay((states.mTransform.position + Vector3.up * .2f), targetVelocity, Color.green, 0.01f, false);
            states.rigidbody.velocity = targetVelocity;
            
            return false;
        }
        void HandleCamRotation()
        {
            float hori  = states.horizontal;
            float vert = states.vertical;

            Vector3 targetDir = states.camera.transform.forward *vert;
            targetDir += states.camera.transform.right * hori;
            targetDir.Normalize();

            targetDir.y = 0;
            if(targetDir == Vector3.zero)
                targetDir = states.mTransform.forward;

            Quaternion tr = Quaternion.LookRotation(targetDir);
            Quaternion targetRotation = Quaternion.Slerp(
                    states.mTransform.rotation, tr, states.delta * states.moveAmount * states.adaptSpeed
                );
                states.mTransform.rotation = targetRotation;
        }
        void HandleAnimations()
        {
            if(states.isGrounded){
                float moveValue = states.moveAmount;
                float forwardValue = 0;
                if(moveValue> 0&& moveValue < .5f)
                {
                    forwardValue = .5f;
                }
                else if(moveValue > 0.5f){
                    forwardValue = 1;
                }
                states.anim.SetFloat("Forward", forwardValue, .2f, states.delta);
            }
            else{

            }
        }
    }  
}