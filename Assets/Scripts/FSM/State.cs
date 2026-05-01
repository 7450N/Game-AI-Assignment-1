using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace FSM
{
    public abstract class State
    {
        protected HFSM fsm; // Reference to the FSM 
        public State(HFSM fsm)
        {
            this.fsm = fsm;
        }
        // Called when entering the state
        public virtual void OnEnter() { }
        // Called every frame while in the state
        public virtual void OnUpdate() { }
        // Called when exiting the state
        public virtual void OnExit() { }
    }

    // ─── Top-level "Pose" state ─────────────────────────────────────────────────
    public class POSE : State
    {
        private float poseDuration = 3f;
        private float timer;
        private bool competitionStart;

        public POSE(HFSM fsm) : base(fsm) { }

        public override void OnEnter()
        {
            Debug.Log("Entering POSE State");
            Debug.Log("Bot is posing for photo.");
            Debug.Log("Press Enter: Competition starts.");
            timer = 0f;
            competitionStart = false;
        }

        public override void OnUpdate()
        {
            timer += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Competition has started. Interrupt posing.");
                competitionStart = true;
            }

            if (competitionStart)
            {
                fsm.SetPrepare();
                return;
            }

            if (timer >= poseDuration)
            {
                Debug.Log("Pose complete. Return to IDLE.");
                fsm.SetIdle();
                return;
            }
        }

        public override void OnExit()
        {
            Debug.Log("Exiting POSE State");
        }
    }

    // ─── Top-level "Protect" state ────────────────────────────────────────────────
    public class PROTECT : State
    {
        private bool competitionStart;
        private float harasserDistance;

        public PROTECT(HFSM fsm) : base(fsm) { }

        public override void OnEnter()
        {
            Debug.Log("Entering PROTECT State");
            Debug.Log("Confronting harasser and protecting the victim cosplayer");
            Debug.Log("Press Enter: Competition starts.");
            Debug.Log("Press I: Harasser runs aways");;
            competitionStart = false;
            harasserDistance = float.MinValue;
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Competition has started. Interrupt protection.");
                competitionStart = true;
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                harasserDistance = 15f; // harasser moved away
                Debug.Log($"Harasser distance is now {harasserDistance}");
            }

            if (competitionStart)
            {
                fsm.SetPrepare();
                return;
            }

            if (harasserDistance > 10f)
            {
                Debug.Log("Harasser gone. Return to IDLE.");
                fsm.SetIdle();
                return;
            }
        }

        public override void OnExit()
        {
            Debug.Log("Exiting PROTECT State");
        }
    }

    // ─── Top-level "Prepare" state ────────────────────────────────────────────────
    public class PREPARE : State
    {   
        public bool isCompeting;

        private bool myTurn;
        private float timer;
        private float waitingTime = 5f;
        public PREPARE(HFSM fsm) : base(fsm) { }

        public override void OnEnter()
        {
            Debug.Log("Entering PREPARE State");
            Debug.Log("The bot is preparing for the competition");
            myTurn = false;
            isCompeting = true;
            timer = 0;
        }

        public override void OnUpdate()
        {
            timer += Time.deltaTime;
            if (timer >= waitingTime)
            {
                Debug.Log("It is now the bot's turn");
                myTurn = true;
            }
            if (myTurn)
            {
                fsm.SetPerform();
                return;
            }
        }

        public override void OnExit()
        {
            Debug.Log("Exiting PREPARE State");
        }
    }

    // ─── Top-level "AwaitResult" state ────────────────────────────────────────────
    public class AWAIT_RESULT : State
    {
        private float score;

        public AWAIT_RESULT(HFSM fsm) : base(fsm) { }

        public override void OnEnter()
        {
            Debug.Log("Entering AWAIT_RESULT state");
            Debug.Log("Press W: Win (>90).");
            Debug.Log("Press L: Lose (<=90).");
            score = float.MinValue;
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                score = 95f;
                Debug.Log($"Bot wins with score {score}");
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                score = 85f;
                Debug.Log($"Bot loses with score {score}");
            }
            if (score > 0)
            {
                if (score > 90f)
                {
                    fsm.SetCelebrate();
                    return;
                }
                else
                {
                    fsm.SetIdle();
                    return;
                }
            }     
        }

        public override void OnExit()
        {
            Debug.Log("Exiting AWAIT_RESULT State");
        }
    }

    // ─── Top-level "Celebrate" state ──────────────────────────────────────────────
    public class CELEBRATE : State
    {
        private float celebrateDuration = 5f;
        private float timer;
        private bool isEngage;
        private float cameraDistance;

        public CELEBRATE(HFSM fsm) : base(fsm) { }

        public override void OnEnter()
        {
            Debug.Log("Entering CELEBRATE state");
            Debug.Log("Bot celebrates!");
            Debug.Log("Press E: Player engages.");
            Debug.Log("Press C: Camera within 10 units.");
            timer = 0f;
            isEngage = false;
            cameraDistance = float.MinValue;
        }

        public override void OnUpdate()
        {
            timer += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Player engages during celebration.");
                isEngage = true;
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                cameraDistance = 9f;
                Debug.Log($"Camera distance = {cameraDistance}");
            }

            if (isEngage)
            {
                fsm.SetConverse();
                return;
            }

            if (cameraDistance < 10f)
            {
                fsm.SetPose();
                return;
            }

            if (timer >= celebrateDuration)
            {
                Debug.Log("Celebration has finished.");
                fsm.SetIdle();
                return;
            }
        }

        public override void OnExit()
        {
            Debug.Log("Exiting CELEBRATE state");
        }
    }
}
