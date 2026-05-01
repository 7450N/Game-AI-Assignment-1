using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class HFSM
    {
        private State currentState;
        [HideInInspector] public Transform transform;

        // Top-level states
        private IDLE idle;
        private CONVERSE converse;
        private POSE pose;
        private PROTECT protect;
        public PREPARE prepare;      // prepare need to be accessed for isCompeting bool variable
        private PERFORM perform;
        private AWAIT_RESULT awaitResult;
        private CELEBRATE celebrate;

        public HFSM(Transform transform)
        {
            // Instantiate each top-level state
            idle = new IDLE(this);
            converse = new CONVERSE(this);
            pose = new POSE(this);
            protect = new PROTECT(this);
            prepare = new PREPARE(this);
            perform = new PERFORM(this);
            awaitResult = new AWAIT_RESULT(this);
            celebrate = new CELEBRATE(this);

            SetState(idle); // Start in Idle
            this.transform = transform;
        }

        private void SetState(State newState)
        {
            currentState?.OnExit();
            currentState = newState;
            currentState?.OnEnter();
        }

        public void Update()
        {
            currentState?.OnUpdate();
        }

        // Helpers to change top-level states
        public void SetIdle() => SetState(idle);
        public void SetConverse() => SetState(converse);
        public void SetPose() => SetState(pose);
        public void SetProtect() => SetState(protect);
        public void SetPrepare() => SetState(prepare);
        public void SetPerform() => SetState(perform);
        public void SetAwaitResult() => SetState(awaitResult);
        public void SetCelebrate() => SetState(celebrate);
    }
}
