using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDodge : MonoBehaviour
{
    private bool DodgeCooldown = false;

    public float DodgeDistance;

    public RawImage DodgeIcon, DodgeSquare;

    private bool DidPlayerDodge;

    public AirTank AirTankScript;


    private void FixedUpdate()
    {
        Dodge();
    }

    private void Dodge()
    {

        //Dodge key pressed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //If the player has air on the tank, the dodge is not on cooldown and is underwater, the player can perform a dodge
            if (!DodgeCooldown && !WaterTrigger.IsOnSurface && !AirTank.AirTankEmpty)
            {
                //Change the alpha of the dodge icon to 0
                DodgeIcon.color = new Color(1f, 1f, 1f, 0f);
                DodgeSquare.color = new Color(1f, 1f, 1f, 0f);

                //Turn the bool to true so the player can't dodge continuously
                DodgeCooldown = true;

                if (Input.GetKey(KeyCode.A)) //If the player clicked the key A, dodge to the left
                {
                    transform.Translate(new Vector3(-DodgeDistance, 0, 0));
                }
                else if (Input.GetKey(KeyCode.D)) //If the player clicked the key D, dodge to the right
                {
                    transform.Translate(new Vector3(DodgeDistance, 0, 0));
                }
                else if (Input.GetKey(KeyCode.S)) //If the player clicked the key S, dodge backwards
                {
                    transform.Translate(new Vector3(0, 0, -DodgeDistance));
                }
                else //If the player clicked W, any other key or no key at all, dodge forward
                {
                    transform.Translate(new Vector3(0, 0, DodgeDistance));
                }

                //Make the DidPlayerDodge bool true to be passed to the PlayerDodged function on another script
                DidPlayerDodge = true;
                AirTankScript.PlayerDodged(DidPlayerDodge);

                //Start the cooldown after dodging
                StartCoroutine("Cooldown");
            }
        }
    }

    IEnumerator Cooldown() //Dodge cooldown
    {
        //Make the DidPlayerDodge bool false to be passed to the PlayerDodged function on another script
        DidPlayerDodge = false;
        AirTankScript.PlayerDodged(DidPlayerDodge);

        //Wait a total of 3 seconds for the dodge to be available again
        //1 second each time so the alpha of the icon is increased slowly
        yield return new WaitForSeconds(0.5f);
        DodgeIcon.color = new Color(1f, 1f, 1f, 0.16f);

        yield return new WaitForSeconds(0.5f);
        DodgeIcon.color = new Color(1f, 1f, 1f, 0.32f);

        yield return new WaitForSeconds(0.5f);
        DodgeIcon.color = new Color(1f, 1f, 1f, 0.48f);

        yield return new WaitForSeconds(0.5f);
        DodgeIcon.color = new Color(1f, 1f, 1f, 0.64f);

        yield return new WaitForSeconds(0.5f);
        DodgeIcon.color = new Color(1f, 1f, 1f, 0.80f);

        yield return new WaitForSeconds(0.5f);
        DodgeIcon.color = new Color(1f, 1f, 1f, 1f);

        DodgeSquare.color = new Color(1f, 1f, 1f, 1f);

        DodgeCooldown = false;

        #region Commented code
        //int Count = 10;
        //float Colour = 0;
        //for (int i = 0; i < Count; i++)
        //{
        //    yield return new WaitForSeconds(3f / Count);
        //    Colour += 1 / Count;
        //    DodgeIcon.color = new Color(1f, 1f, 1f, Colour);
        //}
        #endregion


    }
}
