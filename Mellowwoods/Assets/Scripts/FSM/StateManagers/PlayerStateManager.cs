
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
        
        public bool isLockingOn;

        [Header("Movement Stats")]
        public float frontRayOffset = .5f;
        public float movementSpeed = 4;
        public float adaptSpeed = 10;

        [Header("Camera")]
        public new Transform camera;
        public Cinemachine.CinemachineFreeLook normalCamera;
        public Cinemachine.CinemachineFreeLook lockOnCamera;

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
                    
                    new CharacterMovement(this),

                },
                new List<StateAction>(){
                    //update
                    new InputManager(this),
                },
                new List<StateAction>(){
                    //late update

                }
            );

            locomotion.onEnter = DisableRootMotion;
            State combat = new State(
                new List<StateAction>(){
                    //fixed update

                },
                new List<StateAction>(){
                    //update
                    new MonitorInteraction(this, "IsInteracting", locomotionID),

                },
                new List<StateAction>(){
                    //late update

                }
            );
            combat.onEnter = EnableRootMotion;

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

        #region State Events
        void DisableRootMotion()
        {
            useRootMotion = false;
        }
        void EnableRootMotion()
        {
            useRootMotion = true;
        }
        #endregion

        #region Lockon
        public override void OnAssignLookOverride(Transform target)
        {
            base.OnAssignLookOverride(target);
            normalCamera.gameObject.SetActive(false);
            lockOnCamera.gameObject.SetActive(true);
            lockOnCamera.m_LookAt = target;
        }

        public override void OnClearLookOverride(Transform target)
        {
            base.OnClearLookOverride(target);
            normalCamera.gameObject.SetActive(true);
            lockOnCamera.gameObject.SetActive(false);
        }
        #endregion
    }
}