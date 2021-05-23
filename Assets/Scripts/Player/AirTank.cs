using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirTank : MonoBehaviour
{
    public float CurrentAir;

    public static bool AirTankEmpty;

    public Slider Slider;

    // Start is called before the first frame update
    void Start()
    {
        //Set the oxygen bar
        SetAir(CurrentAir);
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentAir <= 0)
        {
            CurrentAir = 0;

            AirTankEmpty = true;
        }
        else
        {
            AirTankEmpty = false;
        }


        //Check if the player is on the surface of the water
        if (WaterTrigger.IsOnSurface)
        {
            if (CurrentAir < 100)
            {
                CurrentAir += 1 * Time.deltaTime * 10;
            }

            //Update the oxygen bar
            SetAir(CurrentAir);
        }
        else
        {
            CurrentAir -= 1 * Time.deltaTime;

            //Update the oxygen bar
            SetAir(CurrentAir);
        }
    }

    public void SetAir(float Air)
    {
        //Set the oxygen bar
        Slider.value = Air;
    }

    public void PlayerDodged(bool DidDodge)
    {
        if (DidDodge)
        {
            //Subtract 10 oxygen everytime the player dodges
            CurrentAir -= 5;
        }
    }
}