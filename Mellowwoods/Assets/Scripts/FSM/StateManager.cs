using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM{
   
    
    public abstract class StateManager : MonoBehaviour {
        State currentState;
        Dictionary<string, State> allStates =new Dictionary<string, State>();
        private void Start()
        {
            Init();
        }
        public abstract void Init();

        public void FixedTick()
        {
            if(currentState==null)
                return;

            currentState.FixedTick();    
        }
        public void Tick()
        {
            if(currentState==null)
                return;

            currentState.Tick();    
        }
        public void LateTick()
        {
            if(currentState==null)
                return;

            currentState.LateTick();    
        }

        public void ChangeState(string targetID){
            if(currentState != null)
            {
                //Run on exit actions of current state
            }
            State targetState = GetState(targetID);
            //run on enter action of current state

            currentState = targetState;
        }
        State GetState(string targetID)
        {
            allStates.TryGetValue(targetID, out State retVal);
            return retVal;
        }

        protected void RegisterState(string stateID, State state)
        {
            allStates.Add(stateID, state);
        }
    }
}