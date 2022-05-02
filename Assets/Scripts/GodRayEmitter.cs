using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodRayEmitter : MonoBehaviour
{
	GameObject submarine;
	Player player;
	[Header("Spawning Objects")]
	[SerializeField] GameObject Light1;
	
	[Header("Spawning Objects")]
	[Header("Spawning Frequency")]
	[Range(0, 10)]
	[Tooltip("Set seconds after start not spawning anything.")]
	[SerializeField] float start_time = 2;
	[Range(0, 10)]
	[Tooltip("Objects appear after at least seconds")]
	[SerializeField] float minimum_time = 1;
	[Range(1, 20)]
	[Tooltip("Objects appear after seconds at the latest")]
	[SerializeField] float maximum_time = 4;
	
	public bool bubbles = false;
	
	float cooldown = 0;
	float timer = 0;
	
    // Start is called before the first frame update
    void Start()
    {
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
	        if(timer>cooldown){
	        	timer=0;timer=0;
	        	float r = Random.Range(minimum_time, maximum_time);
	        	cooldown = r/PlayerPrefs.GetFloat("TimeSpped");//TimeSpeed will increase the pacing by time
	        	
	        	// Spawn seamines or treasures
	        	Vector3 position = transform.position;
	        	//Quaternion rotation = new Quaternion(0, 0, 0, -47);
	        	Quaternion rotation = Quaternion.Euler(-90, 0, 0);
	        	if(bubbles){rotation = Quaternion.Euler(-90, 0, 0);}
	        	else{rotation = Quaternion.Euler(0, 0, -47);}
	        	Instantiate(Light1, position, rotation);
	        
	        }
    	}
    }
}
