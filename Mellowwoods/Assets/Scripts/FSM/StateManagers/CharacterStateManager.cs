using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public abstract class CharacterStateManager: StateManager
    {
        [Header("References")]
        public Animator anim;
        public new Rigidbody rigidbody;
        public AnimatorHook animatorHook;
        public ClothManager clothManager;

        [Header("Controller Values")]
        public float vertical;
        public float horizontal;
        public bool lockOn;
        public Transform target;
        public float delta;
        public Vector3 rootMovement;

        [Header("States")]
        public bool isGrounded;
        public bool useRootMotion;
        public override void Init(){
            anim = GetComponentInChildren<Animator>();
            rigidbody = GetComponentInChildren<Rigidbody>();
            animatorHook = GetComponentInChildren<AnimatorHook>();
            animatorHook.Init(this);
            clothManager = GetComponentInChildren<ClothManager>();
            anim.applyRootMotion = false;
        }

        public void PlayTargetAnimation(string targetAnim, bool isInteracting)
        {
            anim.SetBool("IsInteracting", isInteracting);
            anim.CrossFade(targetAnim, 0.2f);
        }
        public virtual void OnAssignLookOverride(Transform target)
        {
            target = target;
            if(target!= null)
                lockOn = true;
        }

        public virtual void OnClearLookOverride(Transform target)
        {
            lockOn = false;
        }
    }
}