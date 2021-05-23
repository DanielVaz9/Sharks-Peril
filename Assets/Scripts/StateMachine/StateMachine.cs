using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class StateMachine<AI>
    {
        //To access the AI script
        public State<AI> CurrState { get; set; }

        //Owner of the states
        public AI ObjOwner;

        //Declare the state machine
        public StateMachine(AI _Objowner)
        {
            ObjOwner = _Objowner;
            CurrState = null;
        }

        //Change the states
        public void ChangeState(State<AI> NewState)
        {
            //Exit the state we're currently in
            if (CurrState != null)
            {
                CurrState.StateExit(ObjOwner);
            }
            //Enter new state
            CurrState = NewState;
            CurrState.StateEnter(ObjOwner);
        }

        //Update the states
        public void Update()
        {
            //Update the state if it's not null
            if (CurrState != null)
            {
                CurrState.StateUpdate(ObjOwner);
                Debug.Log(CurrState);
            }
        }
    }

    //This is what every states needs to have
    public abstract class State<AI>
    {
        public abstract void StateEnter(AI _ObjOwner);
        public abstract void StateExit(AI _ObjOwner);
        public abstract void StateUpdate(AI _ObjOwner);
    }

}
