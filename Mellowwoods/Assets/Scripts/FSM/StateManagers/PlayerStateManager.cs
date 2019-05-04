using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class PlayerStateManager: CharacterStateManager
    {
        [Header("Inputs")]
        public float mouseX;
        public float mouseY;
        public float moveAmount;
        public Vector3 rotateDirection;

        public string locomotionID = "Locomotion";
        public string combatID = "Combat";
        public override void Init(){
            base.Init();
            State locomotion = new State(
                new List<StateAction>(){
                    //fixed update
                    new InputManager(this),
                },
                new List<StateAction>(){
                    //update

                },
                new List<StateAction>(){
                    //late update

                }
            );
            State combat = new State(
                new List<StateAction>(){
                    //fixed update

                },
                new List<StateAction>(){
                    //update

                },
                new List<StateAction>(){
                    //late update

                }
            );

            RegisterState(locomotionID, locomotion);
            RegisterState(combatID, combat);
            ChangeState(locomotionID);
        }

        private void FixedUpdate()
        {
            base.FixedTick();
        }

        private void Update()
        {
           base.Tick(); 
        }

        private void LateUpdate()
        {
            base.LateTick();
        }
    }
}