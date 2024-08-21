using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio; 

public class SoundManager : MonoBehaviour
{  
    private static SoundManager instance;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject soundManagerObject = new GameObject("SoundManager");
                instance = soundManagerObject.AddComponent<SoundManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TowerTurn()
    {
        RuntimeManager.PlayOneShot("event:/Tower");
    }

    public void TowerTurnComplete()
    {
        RuntimeManager.PlayOneShot("event:/TurnComplete");
    }

    public void TowerFell()
    {
        RuntimeManager.PlayOneShot("event:/TowerFell");
    }

    public void PuzzleBlock()
    {
        RuntimeManager.PlayOneShot("event:/PuzzleBlock");
    }

    public void PlayLevelWon()
    {
        RuntimeManager.PlayOneShot("event:/LevelWon");
    }

}





