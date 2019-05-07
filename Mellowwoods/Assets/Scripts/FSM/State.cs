using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class State 
    {
        bool forceExit;
        List<StateAction> fixedUpdateActions = new List<StateAction>();
        List<StateAction> updateActions = new List<StateAction>();
        List<StateAction> lateUpdateActions = new List<StateAction>();

        public delegate void OnEnter();
        public OnEnter onEnter;

        public State(List<StateAction> fixedUpdateActions, List<StateAction> updateActions, List<StateAction> lateUpdateActions)
        {
            this.fixedUpdateActions = fixedUpdateActions;
            this.updateActions= updateActions;
            this.lateUpdateActions = lateUpdateActions;
        }

        public void FixedTick()
        {
            ExecuteListOfActions(fixedUpdateActions);   
        }
        public void Tick()
        {
            ExecuteListOfActions(updateActions);
        }
        public void LateTick()
        {            
            ExecuteListOfActions(updateActions);
            forceExit = false;
        }

        void ExecuteListOfActions(List<StateAction> ListOfActions){
            for (int i = 0; i < ListOfActions.Count; i++)
            {
                if(forceExit)
                    return;

                forceExit = ListOfActions[i].Execute();    
            }
        }
    }
}

