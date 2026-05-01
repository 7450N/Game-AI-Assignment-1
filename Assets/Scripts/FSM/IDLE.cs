using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class IDLE : State
    {
        private State lookAround;
        private State roam;
        private State currentSubstate;

        private float cameraDistance;
        private float harasserDistance;

        private bool isEngage;
        private bool competitionStart;

        public IDLE(HFSM fsm) : base(fsm)
        {
            lookAround = new LOOK_AROUND(fsm, this);
            roam = new ROAM(fsm, this);
        }

        public override void OnEnter()
        {
            Debug.Log("Entering IDLE State");
            Debug.Log("Press E: Player engages with the bot.");
            Debug.Log("Press H: Harasser is within 10 units.");
            Debug.Log("Press C: Camera is within 10 units.");
            Debug.Log("Press Enter: Competition starts.");
            competitionStart = false;
            isEngage = false;
            harasserDistance = float.MaxValue;
            cameraDistance = float.MaxValue;

            SetSubstate(lookAround);
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Competition has started.");
                competitionStart = true;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Player engages with the bot.");
                isEngage = true;
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                harasserDistance = 8f;
                Debug.Log($"Harasser distance set to {harasserDistance}");
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                cameraDistance = 9f;
                Debug.Log($"Camera distance set to {cameraDistance}");
            }

            if (competitionStart)
            {
                fsm.SetPrepare();
                return;
            }
            if (isEngage)
            {
                fsm.SetConverse();
                return;
            }
            if (harasserDistance < 10f)
            {
                fsm.SetProtect();
                return;
            }
            if (cameraDistance < 10f)
            {
                fsm.SetPose();
                return;
            }

            // Otherwise, keep updating the current substate
            currentSubstate?.OnUpdate();
        }

        public override void OnExit()
        {
            currentSubstate?.OnExit();
            Debug.Log("Exiting IDLE State");
        }

        private void SetSubstate(State newSub)
        {
            currentSubstate?.OnExit();
            currentSubstate = newSub;
            currentSubstate?.OnEnter();
        }

        // Helper methods to change substates
        public void SetLookAround() => SetSubstate(lookAround);
        public void SetRoam() => SetSubstate(roam);
    }

    public class LOOK_AROUND : State
    {
        private float duration = 10f;
        private float timer;
        protected IDLE parent;           // Reference to the parent IDLE state

        public LOOK_AROUND(HFSM fsm, IDLE parent) : base(fsm) 
        { 
            this.parent = parent;
        }

        public override void OnEnter()
        {
            Debug.Log("Entering LOOK_AROUND Substate");
            timer = 0f;
        }

        public override void OnUpdate()
        {
            timer += Time.deltaTime;
            if (timer >= duration)
            {
                Debug.Log("Looking around for 10 seconds");
                parent.SetRoam();
            }
        }

        public override void OnExit()
        {
            Debug.Log("Exiting LOOK_AROUND Substate");
        }
    }

    public class ROAM : State
    {
        protected IDLE parent;           // Reference to the parent IDLE state

        private Vector3 destination;
        private float speed = 2f;

        public ROAM(HFSM fsm, IDLE parent) : base(fsm) 
        { 
            this.parent = parent;
        }

        public override void OnEnter()
        {
            Debug.Log("Entering ROAM Substate");
            destination = new Vector3(UnityEngine.Random.Range(-5f, 5f), 0, UnityEngine.Random.Range(-5f, 5f));
            Debug.Log($"Roaming to {destination}");
        }

        public override void OnUpdate()
        {
            // Cast fsm to CosplayOwner to get the transform
            
            fsm.transform.position = Vector3.MoveTowards(fsm.transform.position, destination, speed * Time.deltaTime);
            if (Vector3.Distance(fsm.transform.position, destination) < 0.1f)
            {
                Debug.Log("Destination reached!");
                Debug.Log($"The bot is at {fsm.transform.position}");
                parent.SetLookAround();
            }
        }

        public override void OnExit()
        {
            Debug.Log("Exiting ROAM Substate");
        }
    }
}
