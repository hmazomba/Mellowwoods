using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    //Monitors if the play is currently playing an animation
    public class MonitorInteraction : StateAction
    {
        CharacterStateManager states;
        string targetBool;
        string targetState;

        public MonitorInteraction(CharacterStateManager characterStateManager, string targetBool, string targetState)
        {
            states = characterStateManager;
            this.targetBool = targetBool;
            this.targetState = targetState;
        }

        public override bool Execute()
        {
            bool isInteracting = states.anim.GetBool(targetBool);
            
            if(isInteracting)
            {
                
                return false;
            }

            else
            {
                states.ChangeState(targetState);
                
                return true;
            }

            
        }
    }

    
}