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
	
	
    // Start is called before the first frame update
    void Start()
    {
        submarine = GameObject.Find("Submarine");
        player = submarine.GetComponent<Player>();
        
        spawner = GameObject.Find("PrefabSpawner");
        PS = spawner.GetComponent<PrefabSpawner>();
        
        lb = GameObject.Find("Leaderboard");
        leaderboard = lb.GetComponent<Leaderboard>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	if(player.playing==true){
	    	distx = Mathf.Abs(submarine.transform.position.x - transform.position.x);
	    	disty = Mathf.Abs(submarine.transform.position.y - transform.position.y);
	    	
	    	//check if bomb is below or above submarine
	    	//if(submarine.transform.position.y > transform.position.y){subtop=false;}else{subtop=true;}
	    	
	    	//checks if prefab is below the magnet in an given angle
	    	if(distx<angle_of_attraction*disty ||  distx<range_of_attraction){
	    		
	    		Vector3 pos1 = transform.position;
	    		Vector3 pos2 = transform.position;
	    		if(player.top_positive==true){
	    			//float relativeForce = 0;
	    			//if((PS.top-PS.bottom)/2<disty){}
	    			pos2.y+=speed*0.01f*((PS.top-PS.bottom)/2-disty) * PlayerPrefs.GetFloat("TimeSpped");
		    	}else{
		    		pos2.y-=speed*0.01f*((PS.top-PS.bottom)/2-disty) * PlayerPrefs.GetFloat("TimeSpped");
		    	}
	    		
	    		if(pos2.y<PS.top && pos2.y>PS.bottom ){
	    			pos1=pos2;
	    		}
	    		transform.position=pos1;
	    	}
    	}
    }
    void OnTriggerEnter2D(Collider2D other){
    	
    	if(other.tag=="Player"){
    		if(Treasure==true){
    			int points = PlayerPrefs.GetInt("Points");
    			points+=1;
    			PlayerPrefs.SetInt("Points",points);
    			Destroy(gameObject);
    		}
    		if(Mine==true){
    			player.playing=false;
    			//Destroy(submarine);
    			
    			
    			//Submitting the online Highscore
    			StartCoroutine("DieRoutine", 1.0f);
    		//int points = PlayerPrefs.GetInt("Points");
    		//yield return leaderboard.SubmitScoreRoutine(points);
    			
    		}
    	}
    }
    IEnumerator DieRoutine(){
    	int points = PlayerPrefs.GetInt("Points");
    	yield return leaderboard.SubmitScoreRoutine(points);
    	yield return leaderboard.FetchTopHighscoresRoutine();
    	player.dead=true;
    }
}
