using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmodAnimationSfx : MonoBehaviour
{

    void PlaySound(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(path, gameObject);
    }
}
