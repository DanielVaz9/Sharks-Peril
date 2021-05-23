using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkAttack : MonoBehaviour
{
    Animator Animator;

    private float Count = 0;

    public static bool IsSharkAttacking;

    public static bool StopMovingAfterAttack;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    public void AttackPlayer()
    {
        if (CanSeePlayer(Player) && Count < 1)
        {
            //Make the bool true so the player takes damage
            IsSharkAttacking = true;

            //Condition to start animation
            Animator.SetBool("PlayerInRange", true);

            //Start shark's attack cooldown
            StartCoroutine("Cooldown");

            Count++;
        }
    }

    IEnumerator Cooldown() //Attack cooldown
    {
        //"Cooldown" so the shark doesn't glue to the player while walking on "SharkFollowPlayer" script
        StopMovingAfterAttack = true;
        yield return new WaitForSeconds(1.5f);
        StopMovingAfterAttack = false;

        yield return new WaitForSeconds(1.5f);

        Count = 0;

        //Make the bool false so the player doesn't take damage when the shark is not attacking
        IsSharkAttacking = false;

        //Condition to stop animation
        Animator.SetBool("PlayerInRange", false);

    }



    public bool CanSeePlayer(GameObject gameObject)
    {
        float ViewAngle = 10;
        float SightRange = 7;

        Vector3 Direction = Player.transform.position - transform.position;

        float Angle = Vector3.Angle(transform.forward, Direction);

        RaycastHit Hit;

        //If the player is in the cone of vision of the shark, return true
        if (Angle <= ViewAngle && Physics.Raycast(transform.position, Direction, out Hit, SightRange) && Hit.collider.tag == "Player")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
