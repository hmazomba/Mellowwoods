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

        [Header("States")]
        public bool isGrounded;

        [Header("Movement Stats")]
        public float frontRayOffset = .5f;
        public float movementSpeed = 4;
        public float adaptSpeed = 10;

        [Header("Camera")]
        public new Transform camera;

        [HideInInspector]
        public LayerMask ignoreForGroundCheck;


        [HideInInspector]
        public string locomotionID = "Locomotion";
        [HideInInspector]
        public string combatID = "Combat";
        public override void Init(){
            base.Init();
            State locomotion = new State(
                new List<StateAction>(){
                    //fixed update
                    new InputManager(this),
                    new MovePlayerCharacter(this),

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
            ignoreForGroundCheck = ~(1<<9|1<<10);
        }

        private void FixedUpdate()
        {
            delta = Time.fixedDeltaTime;
            base.FixedTick();
        }

        private void Update()
        {
            delta = Time.deltaTime;
           base.Tick(); 
        }

        private void LateUpdate()
        {
            base.LateTick();
        }
    }
}