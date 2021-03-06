using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	GameObject submarine;
	Player player;
 	float timer;
	
    // Start is called before the first frame update
    void Start()
    {
    	submarine = GameObject.Find("Submarine");
        player = submarine.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(player.playing == true){
    		//Count time
	        timer += Time.deltaTime;
	        //Save time
	        PlayerPrefs.SetFloat("Time",timer);
	        
		  	//Adjust UI Text
	        int minutes = Mathf.FloorToInt(timer / 60F);
		  	int seconds = Mathf.FloorToInt(timer % 60F);
		  	int milliseconds = Mathf.FloorToInt((timer * 100F) % 100F);
		 	GetComponent<Text>().text = minutes.ToString ("00") + ":" + seconds.ToString ("00") + ":" + milliseconds.ToString("00");
    	}
    	else{
    		//Reset for game restart
    		timer=0;
    	}
    }
}
