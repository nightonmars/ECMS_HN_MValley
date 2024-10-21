using UnityEngine;
using FMODUnity;

public class MoveBetweenObjects : MonoBehaviour
{
    // Public references to the two GameObjects to move between
    public GameObject pointA;
    public GameObject pointB;
    public bool flockIsMoving = false;
    public bool reverseDirection = false;
    public EventReference birdFlockSoundRef;

    // Speed of movement
    public float speed = 1.0f;

    // Direction flag
    private bool movingToB = true;

    public void StartBirdFlockSound()
    {
        flockIsMoving = true;
        RuntimeManager.PlayOneShotAttached(birdFlockSoundRef, gameObject);
        Debug.Log("move bird flock sound");
        
    }
    void Update()
    {
        
        if (pointA != null && pointB != null && flockIsMoving)
        {
            // Determine the target based on the current direction
            Vector3 target = movingToB ? pointB.transform.position : pointA.transform.position;

            // Move towards the target
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            // If the object reaches the target, reverse direction
            if (Vector3.Distance(transform.position, target) < 0.01f && reverseDirection)
            {
                movingToB = !movingToB;
            }
        }
    }
}