using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticForce : MonoBehaviour
{
	GameObject submarine;
	Player player;
	
	GameObject spawner;
	PrefabSpawner PS;
	
	GameObject lb;
	Leaderboard leaderboard;
	private Vector3 _startPosition;
	
	float disty;
	float distx;
	bool top = false;
	
	[Header("Adjust magnetic force")]
	
	[Range(0, 3)]
	[SerializeField] float angle_of_attraction = 1;
	[Range(1, 10)]
	[SerializeField] float range_of_attraction = 1;
	[Range(0, 10)]
	[SerializeField] float speed = 1;
	
	[Header("Kind of object")]
	
	[SerializeField] bool Mine = false;
	[SerializeField] bool Treasure = false;
	
	public GameObject particles;
	
    void Start()
    {
        submarine = GameObject.Find("Submarine");
        player = submarine.GetComponent<Player>();
        
        spawner = GameObject.Find("PrefabSpawner");
        PS = spawner.GetComponent<PrefabSpawner>();
        
        lb = GameObject.Find("Leaderboard");
        leaderboard = lb.GetComponent<Leaderboard>();
        
    }

    void FixedUpdate()
    {
    	if(player.playing==true){
    		
    		//Checking relative positions to submarine
	    	distx = Mathf.Abs(submarine.transform.position.x - transform.position.x);
	    	disty = Mathf.Abs(submarine.transform.position.y - transform.position.y);
	    	
	    	//checks if object is below the magnet in an given angle and range
	    	if(distx<angle_of_attraction*disty ||  distx<range_of_attraction){
	    		
	    		Vector3 pos1 = transform.position;
	    		Vector3 pos2 = transform.position;
	    		if(player.top_positive==true){
	    			//pos2.y+=speed*0.01f*((PS.top-PS.bottom)/2-disty) * PlayerPrefs.GetFloat("TimeSpped");
	    			pos2.y+=speed*0.01f*((PS.top-PS.bottom-disty)/PS.top-PS.bottom)* 2 * PlayerPrefs.GetFloat("TimeSpped");
		    	}else{
		    		//pos2.y-=speed*0.01f*((PS.top-PS.bottom)/2-disty) * PlayerPrefs.GetFloat("TimeSpped");
		    		pos2.y-=speed*0.01f*((PS.top-PS.bottom-disty)/PS.top-PS.bottom)* 2 * PlayerPrefs.GetFloat("TimeSpped");
		    	}
	    		//checks if object is in range (can not be repelled into space or ground)
	    		if(pos2.y<PS.top && pos2.y>PS.bottom ){
	    			pos1=pos2;
	    		}
	    		transform.position=pos1;
	    	}
    	}
    	else{
    		//If game is finished destory Object
    		Destroy(gameObject);
    	}
    }
    void OnTriggerEnter2D(Collider2D other){
    	
    	if(other.tag=="Player"){
    		if(Treasure==true){
    			//Treasure is collected
    			int points = PlayerPrefs.GetInt("Points");
    			points+=1;
    			PlayerPrefs.SetInt("Points",points);

                FMODUnity.RuntimeManager.PlayOneShotAttached("event:/SFX/UI/Coin", gameObject);
                
                Vector3 position = transform.position;
                Quaternion rotation = new Quaternion(0, 0, 0, 0);
				Instantiate(particles, position, rotation);
	                
    			Destroy(gameObject);
    		}
    		if(Mine==true){
    			
    			//SFX--------------------------------------------------
    			//Explosion Sound (But this object will be terminated, dont add Sound to this object)
    			
    			//End game
    			player.playing=false;
    			player.dead=true;
    			
    			//Submitting the online Highscore
    			StartCoroutine("DieRoutine", 1.0f);
    			
    		}
    	}
    }
    IEnumerator DieRoutine(){
    	//Get points
    	int points = PlayerPrefs.GetInt("Points");
    	//Submitting the online Highscore
    	yield return leaderboard.SubmitScoreRoutine(points);
    }
}
