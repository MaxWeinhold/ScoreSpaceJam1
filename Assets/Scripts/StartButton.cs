using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
	int clicks;
	GameObject submarine;
	Player player;
	
	[SerializeField] GameObject Panel1;
	[SerializeField] GameObject Panel2;
	[SerializeField] GameObject Frame;
	[SerializeField] Text Username_field;
	[SerializeField] Text warning_text;
	
    void Start()
    {
        clicks = 0;
        submarine = GameObject.Find("Submarine");
        player = submarine.GetComponent<Player>();
    	Panel2.SetActive(false);
        Frame.SetActive(true);
        Panel1.SetActive(true);
    }
    
    public void BottonClicked () {
    	
        
    
    	if(clicks==0){
    		
    		//Close Manuals and open Playername Selection
    		clicks++;
    		Panel1.SetActive(false);
    		Panel2.SetActive(true);

            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/SFX/UI/Click", gameObject);
        }
    	else if(clicks==1){
    		//Get Name from Inputfield
    		string userID = Username_field.text.ToString();
    		
    		//Proof Name on Length
    		if(userID.Length<10 && userID.Length>0){
    			//Set Name, close Window and start playing
    			PlayerPrefs.SetString("Username",userID);
    			player.playing=true;
    			Frame.SetActive(false);

                FMODUnity.RuntimeManager.PlayOneShotAttached("event:/SFX/UI/Click", gameObject);
                AudioPlayer.instance.PlaySubBubbles();
    		}
    		else if(userID.Length==0){
    			
    			//SFX-------------------------------------------------------------------------------
    			//Error Sound here
    			
    			//Wrong Input
    			warning_text.text="You need a name for your highscore!";
    		}
    		else{
    			
    			//SFX-------------------------------------------------------------------------------
    			//Error Sound here
    			
    			//Wrong Input
    			warning_text.text="Your name is longer than 10 characters!";
    		}
    	}
    }
}
