using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuelbar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxFuel(int Fuel)
    {
        slider.maxValue = Fuel;
        slider.value = Fuel;
        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int Fuel)
    {
        slider.value = Fuel;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
       
    

}
