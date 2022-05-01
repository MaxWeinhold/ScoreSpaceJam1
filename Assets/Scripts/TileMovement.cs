using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour
{
	GameObject submarine;
	Player player;
	[SerializeField]
	private float movementSpeed = 5f;
	
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
        	transform.position = transform.position + new Vector3(horizontalInput * speed * movementSpeed * Time.deltaTime, 0, 0);
        }
    }
}
