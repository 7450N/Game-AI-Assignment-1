using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

namespace FSM
{
    // ─── Top-level "Perform" state with substates AwaitingTask, Singing, Dancing, Acting ─
    public class PERFORM : State
    {
        private State awaitingTask;
        private State singing;
        private State dancing;
        private State acting;

        private State currentSubstate;
        private bool competitionStart;

        protected PREPARE prepare; // Reference to PREPARE state

        public  bool taskLeft;
        public bool sing;
        public bool dance;
        public bool act;


        public PERFORM(HFSM fsm) : base(fsm)
        {
            awaitingTask = new AWAITING_TASK(fsm, this);
            singing = new SINGING(fsm, this);
            dancing = new DANCING(fsm, this);
            acting = new ACTING(fsm, this);
            prepare = fsm.prepare; // Get reference to PREPARE state
        }

        public override void OnEnter()
        {
            Debug.Log("Entering PERFORM State");
            taskLeft = true;
            sing = false;
            dance = false;
            act = false;
            competitionStart = false;
            SetSubstate(awaitingTask);
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Competition has started. Interrupt perform.");
                competitionStart = true;
            }
            if (!taskLeft)
            {
                if (prepare.isCompeting)
                {
                    Debug.Log("No More Task left to perform in the competition");
                    prepare.isCompeting = false;
                    fsm.SetAwaitResult();
                    return;
                }
                else
                {
                    Debug.Log("No More Task left to perform.");
                    fsm.SetIdle();
                    return;
                }
            }
            if (!(prepare.isCompeting))
            {
                if (competitionStart)
                {
                    fsm.SetPrepare();
                    return;
                }
            }
            currentSubstate?.OnUpdate();
        }

        public override void OnExit()
        {
            currentSubstate?.OnExit();
            Debug.Log("Exiting PERFORM State");
        }

        private void SetSubstate(State newSub)
        {
            currentSubstate?.OnExit();
            currentSubstate = newSub;
            currentSubstate?.OnEnter();
        }

        // Helper methods to change substates
        public void SetSing() => SetSubstate(singing);
        public void SetDance() => SetSubstate(dancing);
        public void SetAct() => SetSubstate(acting);
    }

    // ─── PERFORM substates ─────────────────────────────────────────────────────────
    public class AWAITING_TASK : State
    {
        protected PERFORM parent;       // Reference to the parent PERFORM state
        public AWAITING_TASK(HFSM fsm, PERFORM parent) : base(fsm) 
        { 
            this.parent = parent;
        }

        public override void OnEnter()
        {
            Debug.Log("Entering AWAITING_TASK Substate");
            Debug.Log("Press S: Sing");
            Debug.Log("Press D: Dance");
            Debug.Log("Press A: Act");
        }

        public override void OnUpdate()
        {   
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Requesting Singing");
                parent.sing = true;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Requesting Dancing");
                parent.dance = true;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Requesting Acting");
                parent.act = true;
            }
            if (parent.sing)
            {
                parent.SetSing();
                return;
            }
            if (parent.dance)
            {
                parent.SetDance();
                return;
            }
            if (parent.act)
            {
                parent.SetAct();
                return;
            }
        }

        public override void OnExit()
        {
            Debug.Log("Exiting AWAITING_TASK Substate");
        }
    }

    public class SINGING : State
    {
        private float duration = 10f;
        private float timer;

        protected PERFORM parent;       // Reference to the parent PERFORM state
        public SINGING(HFSM fsm, PERFORM parent) : base(fsm)
        {
            this.parent = parent;
        }

        public override void OnEnter()
        {
            Debug.Log("Entering SINGING substate");
            Debug.Log("La-la-la-lava, ch-ch-ch-chicken");
            Debug.Log("Steve's Lava Chicken, yeah, it's tasty as hell");
            Debug.Log("Ooh, mamacita, now you're ringin' the bell");
            Debug.Log("Crispy and juicy, now you're havin' a snack");
            Debug.Log("Ooh, super spicy, it's a lava attack");
            Debug.Log("Singing Done! Waiting for more tasks!");
            Debug.Log("Press S: Sing Again");
            Debug.Log("Press D: Dance");
            Debug.Log("Press A: Act");
            timer = 0f;
            parent.sing = false;
        }

        public override void OnUpdate()
        {
            timer += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Requesting Singing");
                parent.sing = true;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Requesting Dancing");
                parent.dance = true;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Requesting Acting");
                parent.act = true;
            }
            if (parent.sing)
            {
                parent.SetSing();
                return;
            }
            if (parent.dance)
            {
                parent.SetDance();
                return;
            }
            if (parent.act)
            {
                parent.SetAct();
                return;
            }
            if (timer >= duration)                //if there is no tasks given within 10 seconds
            {
                parent.taskLeft = false;
            }
        }

        public override void OnExit()
        {
            Debug.Log("Exiting SINGING Substate");
        }
    }

    public class DANCING : State
    {
        private float duration = 10f;
        private float timer;

        protected PERFORM parent;       // Reference to the parent PERFORM state
        public DANCING(HFSM fsm, PERFORM parent) : base(fsm)
        {
            this.parent = parent;
        }

        public override void OnEnter()
        {
            Debug.Log("Entering DANCING Substate");
            Debug.Log("Playing Dancing Animation");
            Debug.Log("Dancing Finished");
            Debug.Log("Press S: Sing");
            Debug.Log("Press D: Dance Again");
            Debug.Log("Press A: Act");
            timer = 0f;
            parent.dance = false;
        }

        public override void OnUpdate()
        {
            timer += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Requesting Singing");
                parent.sing = true;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Requesting Dancing");
                parent.dance = true;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Requesting Acting");
                parent.act = true;
            }
            if (parent.sing)
            {
                parent.SetSing();
                return;
            }
            if (parent.dance)
            {
                parent.SetDance();
                return;
            }
            if (parent.act)
            {
                parent.SetAct();
                return;
            }
            if (timer >= duration)                //if there is no tasks given within 10 seconds
            {
                parent.taskLeft = false;
            }
        }

        public override void OnExit()
        {
            Debug.Log("Exiting DANCING Substate");
        }
    }

    public class ACTING : State
    {
        private float duration = 10f;
        private float timer;

        protected PERFORM parent;       // Reference to the parent PERFORM state
        public ACTING(HFSM fsm, PERFORM parent) : base(fsm)
        {
            this.parent = parent;
        }

        public override void OnEnter()
        {
            Debug.Log("Entering ACTING Substate");
            Debug.Log("Dattebayo. Shadown Clone Jutsu. Acting to cast Wind Style: Rasenshuriken.");
            Debug.Log("Acting Finished");
            Debug.Log("Press S: Sing");
            Debug.Log("Press D: Dance");
            Debug.Log("Press A: Act Again");
            timer = 0f;
            parent.act = false;
        }

        public override void OnUpdate()
        {
            timer += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Requesting Singing");
                parent.sing = true;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Requesting Dancing");
                parent.dance = true;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Requesting Acting");
                parent.act = true;
            }
            if (parent.sing)
            {
                parent.SetSing();
                return;
            }
            if (parent.dance)
            {
                parent.SetDance();
                return;
            }
            if (parent.act)
            {
                parent.SetAct();
                return;
            }
            if (timer >= duration)                //if there is no tasks given within 10 seconds
            {
                parent.taskLeft = false;
            }
        }

        public override void OnExit()
        {
            Debug.Log("Exiting ACTING Substate");
        }
    }
}

