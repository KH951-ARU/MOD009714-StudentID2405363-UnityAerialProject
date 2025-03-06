using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCrash : MonoBehaviour
{
    public AudioSource CrashAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            CrashAudioSource.Play();
        }
    }
}
