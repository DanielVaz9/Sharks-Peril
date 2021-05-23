using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

public class Attack : State<AI>
{
    private static Attack _Instance;

    private Attack()
    {
        //Check if an instance has been created before
        if (_Instance != null)
        {
            return;
        }

        _Instance = this;
    }

    //Create an instance so I can use it to call from other scripts
    public static Attack Instance
    {
        get
        {
            //Create the state on the first time the game enters the script
            if (_Instance == null)
            {
                new Attack();
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
        else if (!_ObjOwner.GetSharkFollowPlayer().SharkFollowingPlayer)
        {
            _ObjOwner.stateMachine.ChangeState(Wander.Instance);
        }

        _ObjOwner.GetSharkAttack().AttackPlayer();
    }
}
