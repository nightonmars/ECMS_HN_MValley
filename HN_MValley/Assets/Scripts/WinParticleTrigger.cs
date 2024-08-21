using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinParticleTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //play particle
            StartAllChildParticles();
            SoundManager.Instance.PlayLevelWon(); 
        }
    }


    void StartAllChildParticles()
    {
        // Iterate through all child objects
        foreach (Transform child in transform)
        {  
            ParticleSystem particleSystem = child.GetComponent<ParticleSystem>();
            if (particleSystem != null)
            {
                // Start the particle system
                particleSystem.Play();
            }  
        }
    }
}
