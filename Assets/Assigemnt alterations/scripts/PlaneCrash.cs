using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCrash : MonoBehaviour
{
    public PlaneController PlaneController;
    public AudioSource CrashAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            CrashAudioSource.Play();
            PlaneController.fuelDrain(10);
        }
    }
}
