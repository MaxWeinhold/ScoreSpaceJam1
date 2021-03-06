using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using UnityEngine.UI;

[RequireComponent(typeof(ParticleSystem))]
public class Player : MonoBehaviour
{
	GameObject lb;
	Leaderboard leaderboard;
	
	bool leaderboardui=false;
	public bool playing;
	public bool dead=false;
	
	[Header("Vertical Movement")]
	
	[Tooltip("Speed of vertical Movement")]
	[SerializeField]
	[Range(0, 0.1f)]
	float speed = 1;
	
	[Tooltip("Bottom point on y axis for vertical movement.")]
	[SerializeField]
	[Range(0, 3)]
	float bottom = 1.9f;
	
	[Tooltip("Top point on y axis for vertical movement.")]
	[SerializeField]
	[Range(7, 9)]
	float top = 8.5f;
	
	[Header("Magnet Swap")]
	public bool top_positive = true;
	[SerializeField] GameObject magnet;
	float old_input;
	
	[Header("Leaderboard")]
	[SerializeField] GameObject Panel;
	
	[Header("Others")]
	[SerializeField] GameObject Glitter;
	
//	[Header("Bubbles")]
//	[SerializeField] private ParticleSystem ps;
	
    // Start is called before the first frame update
    void Start()
    {
    	playing=false;
        lb = GameObject.Find("Leaderboard");
        leaderboard = lb.GetComponent<Leaderboard>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	
    	if(dead==false){
    		
    		
    		leaderboardui=false;
    		
	    	//Vertical Movement Section____________________________
	    	
	    	//Input
	    	float inputY = Input.GetAxis("Vertical");
	    	
	    	Vector3 pos1 = transform.position;
	    	Vector3 pos2 = transform.position;
	    	
	    	pos2.y+=speed*inputY;
	    	
	    	//Check boundaries in which between the player can move
	    	if(pos2.y<top && pos2.y>bottom){
	    		pos1=pos2;
	    	}
	    	
	    	//SFX-------------------------------------------------------------------------------
	    	if(inputY<-0.1f){
	    		//Sound for ascending submarine
	    	}
	    	else if((inputY>0.1f)){
	    		//Sound for diving submarine
	    	}
	    	
	    	//update position
	    	transform.position=pos1;
	   
	    	//Horizontally Movement Section____________________
	    	
	    	//Input
	    	float inputX = Input.GetAxis("Horizontal");
	    	
	    	//Adjust Speed depending on Input
	    	if(inputX<-0.1f){
	    		PlayerPrefs.SetFloat("Speed",0.5f);

				//	    		var emission = ps.emission;
				//       			emission.rateOverTime = 10;

				FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Speed", 0.5f);
	    	}
	    	else if(inputX>0.1f){
	    		PlayerPrefs.SetFloat("Speed",2);

				//	    		var emission = ps.emission;
				//       			emission.rateOverTime = 70;

				FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Speed", 2f);
			}
	    	else{
	    		PlayerPrefs.SetFloat("Speed",1);

				//	    		var emission = ps.emission;
				//       			emission.rateOverTime = 40;

				FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Speed", 1f);
			}
	    	
	    	//Magent Swap Action____________________
	    	
	    	//Magnet Swap Animation
	    	GetComponent<Animator>().SetBool("MagnetOnTop", top_positive);
	    	
	    	//input
	    	float inputSwap = Input.GetAxis("Jump");
	    	
	    	//SFX-------------------------------------------------------------------------------
	    	//Sound for magnet Swaping, but we will wait, because we may change that horsehoe magnet anyway!
	    	
	    	//swap the magnet when pressing spacebar
	    	if(old_input<inputSwap){
	    		
	    		if(top_positive==true){
	    			
	    			top_positive=false;

					FMODUnity.RuntimeManager.PlayOneShotAttached("event:/SFX/Submarine/Submarine_Magnet_Up", gameObject);
				}
	    		else{
	    			
	    			top_positive=true;

					FMODUnity.RuntimeManager.PlayOneShotAttached("event:/SFX/Submarine/Submarine_Magnet_Down", gameObject);

				}
	    		old_input=1;
	    	}
	    	if(inputSwap==0){old_input=0;}
    	}
    	else{
    		//Set Leaderboard active after death
    		Panel.SetActive(true);
    		
    		if(leaderboardui==false){
    			leaderboardui=true;
    			//SFX----------------------------------------------------------------------------------------
    			//Unfold Leaderboard UI Sound
    		}
    	}
    }
    void OnTriggerEnter2D(Collider2D other){
    
    	if (other.tag == "Obstacle")
    	{
    		//End game
    		playing=false;
    		dead=true;

			AudioPlayer.instance.StopSubBubbles();
			AudioPlayer.instance.StopMainMusic();
			FMODUnity.RuntimeManager.PlayOneShotAttached("event:/SFX/Submarine/Submarine_Collision", gameObject);
    		
    		//Submitting the online Highscore
    		StartCoroutine("DieRoutine", 1.0f);
    	}
    	if (other.tag == "Treasure"){
    		//Glitter.GetComponent<ParticleSystem>().Play();
    	}
    }
    IEnumerator DieRoutine(){
    	//Get points
    	int points = PlayerPrefs.GetInt("Points");
    	//Submitting the online Highscore
    	yield return leaderboard.SubmitScoreRoutine(points);
    }
}