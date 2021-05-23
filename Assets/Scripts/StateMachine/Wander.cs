using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

public class Wander : State<AI>
{
    private static Wander _Instance;

    private Wander()
    {
        //Check if an instance has been created before
        if (_Instance != null)
        {
            return;
        }

        _Instance = this;
    }

    //Create an instance so I can use it to call from other scripts
    public static Wander Instance
    {
        get
        {
            //Create the state on the first time the game enters the script
            if (_Instance == null)
            {
                new Wander();
            }
            return _Instance;
        }
    }

    public override void StateEnter(AI _ObjOwner)
    {

    }

    public override void StateExit(AI _ObjOwner)
    {

    }

    public override void StateUpdate(AI _ObjOwner)
    {
        if (_ObjOwner.GetSharkFollowPlayer().Distance < 20)
        {
            _ObjOwner.stateMachine.ChangeState(Follow.Instance);
        }

        _ObjOwner.GetSharkWander().Move();


    }
}