using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public bool playing;
	
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
	
    // Start is called before the first frame update
    void Start()
    {
    	playing=true;;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	
    	//Vertical Movement Section------------------------------------------
    	
    	//Input
    	float inputY = Input.GetAxis("Vertical");
    	
    	Vector3 pos1 = transform.position;
    	Vector3 pos2 = transform.position;
    	
    	pos2.y+=speed*inputY;
    	
    	//Check boundaries in which between the player can move
    	if(pos2.y<top && pos2.y>bottom){
    		pos1=pos2;
    	}
    	
    	//update position
    	transform.position=pos1;
    	
    	//Magent Swap Action-------------------------------------------------
    	
    	//input
    	float inputSwap = Input.GetAxis("Jump");
    	
    	//swap the magnet when pressing spacebar
    	if(old_input<inputSwap){
    		if(top_positive==true){
    			top_positive=false;
    		}
    		else{
    			top_positive=true;
    		}
    		old_input=1;
    	}
    	if(inputSwap==0){old_input=0;}
    	
    	//Placeholder. Later we will have an Animation for indicating visually that magnet is swaped
    	magnet.GetComponent<SpriteRenderer>().flipY=top_positive;
    	
    }
}
