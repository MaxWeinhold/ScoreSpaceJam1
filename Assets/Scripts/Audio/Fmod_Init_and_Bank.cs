using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fmod_Init_and_Bank : MonoBehaviour
{

    bool audioResumed = false;
    void Awake()
    {
        if (!audioResumed)
        {
            var result = FMODUnity.RuntimeManager.CoreSystem.mixerSuspend();
            //  Debug.Log(result);
            result = FMODUnity.RuntimeManager.CoreSystem.mixerResume();
            //  Debug.Log(result);
            audioResumed = true;
        }

        FMODUnity.RuntimeManager.LoadBank("Main");
        FMODUnity.RuntimeManager.LoadBank("Main.strings");

    }


}
