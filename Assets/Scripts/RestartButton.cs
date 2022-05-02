using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
	GameObject submarine;
	Player player;
	[SerializeField] GameObject Frame;
	
    void Start()
    {
        submarine = GameObject.Find("Submarine");
        player = submarine.GetComponent<Player>();
        
    }

    public void BottonClicked () {
    	
    	//SFX-------------------------------------------------------------------------------
    	//ButtonClick here
    	
    	//Reset Points
    	PlayerPrefs.SetInt("Points",0);
    	
    	//Activate Player
    	player.dead=false;
    	player.playing=true;

        AudioPlayer.instance.PlaySubBubbles();
        AudioPlayer.instance.PlayMainMusic();
    	
    	//Close Leaderboard Window
    	Frame.SetActive(false);
    }
}
