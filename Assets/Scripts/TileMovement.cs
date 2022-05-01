using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour
{
	GameObject submarine;
	Player player;
	[SerializeField]
	private float movementSpeed = 5f;
 	float timer;
 	public float timespeed = 1;
	private int time_relation = 250;
 	[SerializeField]
	private int max_timespeed = 10;
	
    // Start is called before the first frame update
    void Start()
    {
        submarine = GameObject.Find("Submarine");
        player = submarine.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
    	//get the Input from Horizontal axis
        //float horizontalInput = Input.GetAxis("Horizontal");
        float horizontalInput = -1;
        //get the Input from Vertical axis
        //float verticalInput = Input.GetAxis("Vertical");
        float verticalInput = 0;
    	
        float speed = PlayerPrefs.GetFloat("Speed");
        
        if(player.playing){
	        
        	timer = PlayerPrefs.GetFloat("Time");
        	if(timespeed<max_timespeed){
        		timespeed = 1 + timer/time_relation;
        		PlayerPrefs.SetFloat("TimeSpped",timespeed);
        	}
        	
        	transform.position = transform.position + new Vector3(horizontalInput * speed * timespeed * movementSpeed * Time.deltaTime, 0, 0);
        }
        else{
        	timespeed = 1;
        	PlayerPrefs.SetFloat("TimeSpped",timespeed);
        }
    }
}
