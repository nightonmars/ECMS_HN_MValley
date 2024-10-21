using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlockTrigger : MonoBehaviour
{
    [SerializeField] MoveBetweenObjects moveBetweenObjects;
    [SerializeField] private NVBoids boids;
    [SerializeField] private bool moveFlock = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (moveFlock)
            {
                boids.StartBirdMovement();    
                moveBetweenObjects.StartBirdFlockSound();
            }
        }
    }
}
