using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer instance;

    private FMOD.Studio.EventInstance MainMusic;
    private FMOD.Studio.EventInstance SubmarineBubbles;



    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);

        MainMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Main_Music");
        SubmarineBubbles = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Submarine/Submarine_Bubbles");
    }



    public void PlayMainMusic()
    {
        MainMusic.start();
    }
    public void StopMainMusic()
    {
        MainMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void PlaySubBubbles()
    {
        SubmarineBubbles.start();
    }

    public void StopSubBubbles()
    {
        SubmarineBubbles.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);  
    }
}
