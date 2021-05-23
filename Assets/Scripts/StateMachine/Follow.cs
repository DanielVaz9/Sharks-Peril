using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

public class Follow : State<AI>
{
    private static Follow _Instance;

    private Follow()
    {
        //Check if an instance has been created before
        if (_Instance != null)
        {
            return;
        }

        _Instance = this;
    }

    //Create an instance so I can use it to call from other scripts
    public static Follow Instance
    {
        get
        {
            //Create the state on the first time the game enters the script
            if (_Instance == null)
            {
                new Follow();
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
        if (_ObjOwner.GetSharkFollowPlayer().Distance > 20)
        {
            _ObjOwner.stateMachine.ChangeState(Wander.Instance);
        }
        else if (_ObjOwner.GetSharkFollowPlayer().Distance < 7)
        {
            _ObjOwner.stateMachine.ChangeState(Attack.Instance);
        }

        _ObjOwner.GetSharkFollowPlayer().FollowPlayer();

    }
}
