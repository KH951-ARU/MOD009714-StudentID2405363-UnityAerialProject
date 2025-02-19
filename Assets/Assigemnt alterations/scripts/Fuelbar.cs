using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuelbar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxFuel(int Fuel)
    {
        slider.maxValue = Fuel;
        slider.value = Fuel;
    }
    public void SetHealth(int Fuel)
    {
        slider.value = Fuel;
    }
       
    

}
