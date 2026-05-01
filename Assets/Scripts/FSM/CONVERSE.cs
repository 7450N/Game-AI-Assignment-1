using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    // ─── Top-level "Converse" state with several substates ────────────────────
    public class CONVERSE : State
    {
        private State giveDirection;
        private State giveBotInfo;
        private State givePlayerInfo;
        private State rateCostume;
        private State recommendAnime;
        private State greet;
        private State currentSubstate;

        private bool isEngage;
        private bool competitionStart;

        public CONVERSE(HFSM fsm) : base(fsm)
        {
            greet = new GREET(fsm, this);
            giveDirection = new GIVE_DIRECTION(fsm, this);
            giveBotInfo = new GIVE_BOT_INFO(fsm, this);
            givePlayerInfo = new GIVE_PLAYER_INFO(fsm, this);
            rateCostume = new RATE_COSTUME(fsm, this);
            recommendAnime = new RECOMMEND_ANIME(fsm, this);
        }

        public override void OnEnter()
        {
            Debug.Log("Entering CONVERSE State");
            competitionStart = false;
            isEngage = true;
            SetSubstate(greet);
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Competition has started.");
                competitionStart = true;
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("Player asks to perform");
                fsm.SetPerform();
                return;
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("Player asks for a photo");
                fsm.SetPose();
                return;
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                Debug.Log("Player stops engaging");
                isEngage = false;
            }

            if (competitionStart)
            {
                fsm.SetPrepare();
                return;
            }
            if (!isEngage)
            {
                fsm.SetIdle();
                return;
            }

            currentSubstate?.OnUpdate();
        }

        public override void OnExit()
        {
            currentSubstate?.OnExit();
            Debug.Log("Exiting CONVERSE State");
        }

        private void SetSubstate(State newSub)
        {
            currentSubstate?.OnExit();
            currentSubstate = newSub;
            currentSubstate?.OnEnter();
        }

        // ─── Helper methods to set substates ──────────────────────────────────────
        public void SetGreet() => SetSubstate(greet);
        public void SetGiveDirection() => SetSubstate(giveDirection);
        public void SetGiveBotInfo() => SetSubstate(giveBotInfo);
        public void SetGivePlayerInfo() => SetSubstate(givePlayerInfo);
        public void SetRateCostume() => SetSubstate(rateCostume);
        public void SetRecommendAnime() => SetSubstate(recommendAnime);
    }

    // ─── CONVERSE substates ────────────────────────────────────────────────────
    public class GREET : State
    {
        protected CONVERSE parent;       // Reference to the parent CONVERSE state
        public GREET(HFSM fsm, CONVERSE parent) : base(fsm) 
        { 
            this.parent = parent;
        }

        public override void OnEnter()
        {
            Debug.Log("Entering GREET Substate");
            Debug.Log("Hello! Welcome to the cosplay event. How may I assist you today?");
            Debug.Log("Press 1: Ask for directions.");
            Debug.Log("Press 2: Ask about bot’s character.");
            Debug.Log("Press 3: Ask about your character.");
            Debug.Log("Press 4: Ask to rate your costume.");
            Debug.Log("Press 5: Ask for anime recommendations.");
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Player: Where is the toilet?");
                parent.SetGiveDirection();
                return;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("Player: Tell me about your character.");
                parent.SetGiveBotInfo();
                return;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log("Player: Tell me about my character.");
                parent.SetGivePlayerInfo();
                return;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Debug.Log("Player: Rate my costume.");
                parent.SetRateCostume();
                return;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                Debug.Log("Player: Any anime recommendations?");
                parent.SetRecommendAnime();
                return;
            }
        }

        public override void OnExit()
        {
            Debug.Log("Exiting GREET Substate");
        }
    }

    public class GIVE_DIRECTION : State
    {
        protected CONVERSE parent;       // Reference to the parent CONVERSE state
        private bool directionFinish;
        public GIVE_DIRECTION(HFSM fsm, CONVERSE parent) : base(fsm)
        {
            this.parent = parent;
        }

        public override void OnEnter()
        {
            Debug.Log("Entering GIVE_DIRECTION Substate");
            directionFinish = false;
            Debug.Log("The toilet is on the left side of the fan meeting booth.");
            directionFinish = true;
        }

        public override void OnUpdate()
        {
            if (directionFinish)
            {
                Debug.Log("Giving direction has done.");
                parent.SetGreet();
                return;
            }
        }

        public override void OnExit()
        {
            Debug.Log("Exiting GIVE_DIRECTION Substate");
        }
    }

    public class GIVE_BOT_INFO : State
    {
        protected CONVERSE parent;       // Reference to the parent CONVERSE state
        public GIVE_BOT_INFO(HFSM fsm, CONVERSE parent) : base(fsm)
        {
            this.parent = parent;
        }

        public override void OnEnter()
        {
            Debug.Log("Entering GIVE_BOT_INFO Substate");
            Debug.Log("I’m cosplaying as Naruto Uzumaki from Naruto Shippuden.");
            Debug.Log("Press 0: Return to greet.");
            Debug.Log("Press 1: Ask about player's character.");
            Debug.Log("Press 2: Ask for anime recommendations.");
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                Debug.Log("Returning to greet.");
                parent.SetGreet();
                return;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Player: Tell me more about my character.");
                parent.SetGivePlayerInfo();
                return;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("Player: Requesting anime recommendations.");
                parent.SetRecommendAnime();
                return;
            }
        }

        public override void OnExit()
        {
            Debug.Log("Exiting GIVE_BOT_INFO Substate");
        }
    }

    public class GIVE_PLAYER_INFO : State
    {
        protected CONVERSE parent;       // Reference to the parent CONVERSE state
        public GIVE_PLAYER_INFO(HFSM fsm, CONVERSE parent) : base(fsm)
        {
            this.parent = parent;
        }

        public override void OnEnter()
        {
            Debug.Log("Entering GIVE_PLAYER_INFO substate");
            Debug.Log("You dress as Sasuke Uchiha, my rival.");
            Debug.Log("Press 0: Return to greet.");
            Debug.Log("Press 1: Ask about bot character.");
            Debug.Log("Press 2: Ask to rate costume.");
            Debug.Log("Press 3: Request anime recommendations.");
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                Debug.Log("Returning to greet.");
                parent.SetGreet();
                return;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Player: Tell me about bot’s character.");
                parent.SetGiveBotInfo();
                return;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("Player: Rate my costume.");
                parent.SetRateCostume();
                return;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log("Player: Request anime recommendations.");
                parent.SetRecommendAnime();
                return;
            }
        }

        public override void OnExit()
        {
            Debug.Log("Exiting GIVE_PLAYER_INFO Substate");
        }
    }

    public class RATE_COSTUME : State
    {
        protected CONVERSE parent;       // Reference to the parent CONVERSE state
        private bool ratingFinish;
        public RATE_COSTUME(HFSM fsm, CONVERSE parent) : base(fsm)
        {
            this.parent = parent;
        }

        public override void OnEnter()
        {
            Debug.Log("Entering RATE_COSTUME Substate");
            ratingFinish = false;
            Debug.Log("Your costume is amazing and accurate with the manga! I would rate it 9 out of 10.");
            ratingFinish = true;
        }

        public override void OnUpdate()
        {
            if (ratingFinish)
            {
                Debug.Log("Costume Rating has done.");
                parent.SetGreet();
                return;
            }
        }

        public override void OnExit()
        {
            Debug.Log("Exiting RATE_COSTUME Substate");
        }
    }

    public class RECOMMEND_ANIME : State
    {
        private bool recommendFinish;
        protected CONVERSE parent;       // Reference to the parent CONVERSE state
        public RECOMMEND_ANIME(HFSM fsm, CONVERSE parent) : base(fsm)
        {
            this.parent = parent;
        }

        public override void OnEnter()
        {
            Debug.Log("Entering RECOMMEND_ANIME substate");
            recommendFinish = false;
            Debug.Log("You should watch Attack on Titan, Demon Slayer, and My Hero Academia.");
            recommendFinish = true;
        }

        public override void OnUpdate()
        {
            if (recommendFinish)
            {
                Debug.Log("Anime Recommendation has done.");
                parent.SetGreet();
                return;
            }
        }
        public override void OnExit()
        {
            Debug.Log("Exiting RECOMMEND_ANIME Substate");
        }
    }
}