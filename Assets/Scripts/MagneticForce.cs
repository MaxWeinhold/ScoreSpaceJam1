using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticForce : MonoBehaviour
{
	GameObject submarine;
	Player player;
	float disty;
	float distx;
	bool top = false;
	
	[Header("Adjust magnetic force")]
	
	[Range(0, 3)]
	[SerializeField] float angle_of_attraction = 1;
	[Range(0, 3)]
	[SerializeField] float speed = 1;
	
	[Header("Kind of object")]
	
	[SerializeField] bool Mine = false;
	[SerializeField] bool Treasure = false;
	
    // Start is called before the first frame update
    void Start()
    {
        submarine = GameObject.Find("Submarine");
        player = submarine.GetComponent<Player>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	distx = Mathf.Abs(submarine.transform.position.x - transform.position.x);
    	disty = Mathf.Abs(submarine.transform.position.y - transform.position.y);
    	
    	//check if bomb is below or above submarine
    	//if(submarine.transform.position.y > transform.position.y){top=false;}else{top=true;}
    	
    	//checks if prefab is below the magnet in an given angle
    	if(distx<angle_of_attraction*disty){
    		Vector3 pos1 = transform.position;
    		
    		if(player.top_positive==true){
    			//vertical attraction
    			if(!top){pos1.y+=speed*0.01f;}
    			else{pos1.y+=speed*0.01f;}
    		}else{
    			//vertical repeliation
    			if(top){pos1.y-=speed*0.01f;}
    			else{pos1.y-=speed*0.01f;}
    		}
    		transform.position=pos1;
    	}
    }
    void OnTriggerEnter2D(Collider2D other){
    	
    	if(other.tag=="Player"){
    		print("Teeeeeest");
    		if(Treasure==true){
    			int points = PlayerPrefs.GetInt("Points");
    			points+=1;
    			PlayerPrefs.SetInt("Points",points);
    			Destroy(gameObject);
    		}
    		if(Mine==true){
    			player.playing=false;
    			Destroy(submarine);
    		}
    	}
    }
}
