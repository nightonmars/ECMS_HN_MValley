using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAmbAndMusic : MonoBehaviour
{
    [SerializeField] FMOD_Ambience fMOD_Ambience;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            fMOD_Ambience.StopAll();
        }
        
    }
}
