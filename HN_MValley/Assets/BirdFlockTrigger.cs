using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlockTrigger : MonoBehaviour
{
    [SerializeField] private GameObject birdPrefab;
    [SerializeField] MoveBetweenObjects moveBetweenObjects;
    [SerializeField] private NVBoids boids;
    [SerializeField] private bool moveFlock = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            birdPrefab.SetActive(true);
            if (moveFlock)
            {
                boids.StartBirdMovement();    
                moveBetweenObjects.StartBirdFlockSound();
            }
        }
    }
}
