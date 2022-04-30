using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	float inputY = Input.GetAxis("Vertical");
    	
    	Vector3 pos1 = transform.position;
    	Vector3 pos2 = transform.position;
    	
    	pos2.y+=speed*inputY;
    	
    	if(pos2.y<top && pos2.y>bottom){
    		pos1=pos2;
    	}
    	
    	transform.position=pos1;
    	//print(transform.position.y);
    }
}
