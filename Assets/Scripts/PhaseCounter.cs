using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseCounter : MonoBehaviour
{
	GameObject submarine;
	Player player;
	bool beginning = true;
	
	int Phase;
	
	[Header("Phase Duration")]
	[Range(10, 40)]
	[Tooltip("Set seconds after start not spawning anything.")]
	[SerializeField] float start_time = 2;
	[Range(15, 50)]
	[Tooltip("Objects appear after at least seconds")]
	[SerializeField] float minimum_time = 1;
	[Range(10, 40)]
	[Tooltip("Objects appear after seconds at the latest")]
	[SerializeField] float maximum_time = 4;
	float cooldown = 0;
	float timer = 0;
	
    // Start is called before the first frame update
    void Start()
    {
    	int Phase = -1;
		submarine = GameObject.Find("Submarine");
        player = submarine.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(player.playing){
	        timer += Time.deltaTime;
	        
	        // for the start take the start_time as cooldown
	        if(cooldown==0){
	        	cooldown=start_time;
	        }
	        //cooldown is down, next prefab will be spawned
	        if(timer>cooldown){
	        	// set up the next cooldown time randomly
	        	timer=0;
	        	float r = Random.Range(minimum_time, maximum_time);
	        	cooldown = r;//TimeSpeed will increase the pacing by time
	        	
	        	if(beginning){beginning=false;}else{
	        		Phase++;
	        	}
	        	
	        	
	        	if(Phase>1){Phase=0;}
	        	PlayerPrefs.SetInt("Phase",Phase);
	        	//print("TestYo");
	        }
    		
    	}
    	else{
    		Phase=0;
    		beginning=true;
    	}
    }
}
