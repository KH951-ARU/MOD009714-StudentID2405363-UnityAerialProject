using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject PlaneController;
    float currentTime;
    public float startingTime = 70;
    [SerializeField] Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text =("Time:" + " " +currentTime.ToString("0"));

        if (currentTime <= 0)
        {
            currentTime = 0;
            Destroy(PlaneController);
        }
    }
}
