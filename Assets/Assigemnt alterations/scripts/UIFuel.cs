using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFuel : MonoBehaviour
{

    [SerializeField] private Image FuelBarSprite;

    public void UpdateFuelBar( float maxFuel, float currentFuel)
    { 
        FuelBarSprite.fillAmount = currentFuel / maxFuel;
    }


}








//https://youtu.be/6U_OZkFtyxY?si=TvTP29awKBKcdVCx