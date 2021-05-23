using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

public class AI : MonoBehaviour
{
    public StateMachine<AI> stateMachine { get; set; }

    private SharkAttack _SharkAttack;

    private SharkFollowPlayer _SharkFollowPlayer;

    private SharkWander _SharkWander;

    // Start is called before the first frame update
    void Start()
    {
        //Get the scripts needed
        _SharkAttack = GetComponent<SharkAttack>();
        _SharkFollowPlayer = GetComponent<SharkFollowPlayer>();
        _SharkWander = GetComponent<SharkWander>();

        //Start the state machine
        stateMachine = new StateMachine<AI>(this);
        stateMachine.ChangeState(Wander.Instance);
    }

    public SharkAttack GetSharkAttack()
    {
        return _SharkAttack;
    }

    public SharkFollowPlayer GetSharkFollowPlayer()
    {
        return _SharkFollowPlayer;
    }

    public SharkWander GetSharkWander()
    {
        return _SharkWander;
    }

    // Update is called once per frame
    void Update()
    {
        //Update the state machine
        stateMachine.Update();
    }
}
