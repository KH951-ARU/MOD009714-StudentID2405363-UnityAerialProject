using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public bool PlaneisDestroyed = false;
    public GameObject PlaneController;
    public float currentTime;
    public float startingTime = 70;
    [SerializeField] Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        PlaneisDestroyed = false;
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlaneisDestroyed == false)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = ("Time:" + " " + currentTime.ToString("0")); // time is displayed in the game
            PlaneisDestroyed = PlaneController.GetComponent<PlaneController>().PlaneisDestroy; // checks if the plane is destroyed
        }

       
               if (currentTime <= 0 && PlaneisDestroyed == false)
               {    
            currentTime = 0;
            
            PlaneisDestroyed = true;
                          
               }
        if (PlaneisDestroyed == true && currentTime >= 0 )// if the plane is destroyed and the time is still running
        {
            countdownText.text = ("Game Over" + " time was left: " + currentTime.ToString("0.000")); // game over message is displayed
        }
    }
}
