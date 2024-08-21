using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootStep : MonoBehaviour
{
    [SerializeField] FootStepManager footStepManager;

    public void FootStepDown(int kind)
    {
        footStepManager.PlayFootStep(kind);
    }
}
