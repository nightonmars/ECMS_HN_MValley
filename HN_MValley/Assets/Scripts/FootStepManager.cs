using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio; 


public class FootStepManager : MonoBehaviour
{
    EventInstance footStep;
    public void PlayFootStep(int kindLayer)
    {
        
        footStep = RuntimeManager.CreateInstance("event:/FootSteps/FootSteps");
        footStep.start();
        footStep.release();
        footStep.setParameterByName("Terrain", kindLayer); 
    }
}
