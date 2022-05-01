using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance;

    private FMOD.Studio.EventInstance MainMusic;



    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);

        MainMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Main_Music");
    }



    public void PlayMainMusic()
    {
        MainMusic.start();
    }
    public void StopMainMusic()
    {
        MainMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

}
