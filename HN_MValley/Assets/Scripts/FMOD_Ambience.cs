using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class FMOD_Ambience : MonoBehaviour
{
    private EventInstance water;
    private EventInstance seaGulls;
    private EventInstance music;

    private void Start()
    {
        PlayWater();
        PlaySeaGulls();
        PlayMusic();
    }


    private void PlayWater()
    {
        water = RuntimeManager.CreateInstance("event:/Water");
        water.start();
        water.release();
    }


    private void PlaySeaGulls()
    {
        seaGulls = RuntimeManager.CreateInstance("event:/Seagulls");
        seaGulls.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
        seaGulls.start();
        seaGulls.release();
    }


    private void PlayMusic()
    {
        music = RuntimeManager.CreateInstance("event:/Music");
        music.start();
        music.release();
    }

    public void StopAll()
    {
        water.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        seaGulls.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

}

