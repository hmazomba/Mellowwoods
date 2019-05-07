using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FSM{
    public class AnimatorHook : MonoBehaviour
    {
        CharacterStateManager states;
        // Start is called before the first frame update
        public virtual void Init(CharacterStateManager stateManager)
        {
            states = (CharacterStateManager)stateManager;
        }

        private void OnAnimatorMove() 
        {     
            OnAnimatorMoveOverride();        
        }

        protected virtual void OnAnimatorMoveOverride()
        {
            if(states.useRootMotion == false)
                return;

            if(states.isGrounded && states.delta > 0)
            {
                Vector3 rootTransformVelocity = (states.anim.deltaPosition)/ states.delta;
                rootTransformVelocity.y = states.rigidbody.velocity.y;
                states.rigidbody.velocity = rootTransformVelocity;
            }
        }
    }
}

