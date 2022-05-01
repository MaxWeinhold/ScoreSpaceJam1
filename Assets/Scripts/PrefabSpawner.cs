using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
	GameObject submarine;
	Player player;
	
	[Header("Vertical Spawn Locations")]
	
	[Tooltip("Bottom spawn point.")]
	[SerializeField]
	[Range(0, 3)]
	public float bottom = 1.9f;
	
	[Tooltip("Top spawn point.")]
	[SerializeField]
	[Range(8, 10)]
	public float top = 8.5f;
	
	[Header("Spawning Objects")]
	[SerializeField] GameObject SeaMine;
	[SerializeField] GameObject Treasure;
	
	[Header("Spawning Frequency")]
	[Range(0, 10)]
	[SerializeField] float start_time = 2;
	[Range(0, 10)]
	[SerializeField] float minimum_time = 1;
	[Range(1, 20)]
	[SerializeField] float maximum_time = 4;
	float cooldown = 0;
	
	float timer = 0;
	
    // Start is called before the first frame update
    void Start()
    {
		PlayerPrefs.SetInt("Points",0);
		submarine = GameObject.Find("Submarine");
        player = submarine.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        // for the start take the start_time as cooldown
        if(cooldown==0){
        	cooldown=start_time;
        }
        
        //cooldown is down, next prefab will be spawned
        if(timer>cooldown && player.playing){
        	// set up the next cooldown time randomly
        	timer=0;
        	float r = Random.Range(minimum_time, maximum_time);
        	cooldown = r/PlayerPrefs.GetFloat("TimeSpped");
        	
        	// Spawn seamines or treasures
        	Vector3 position = transform.position;
        	
        	//randomly select wether object is above or below submarine
        	int r2 = Random.Range(0, 2);
        	if(r2==0){position.y=bottom;}
        	else{position.y=top;}
        	Quaternion rotation = new Quaternion(0, 0, 0, 0);
        	
        	//randomly select treasure or seamine
        	int r3 = Random.Range(0, 2);
        	if(r3==0){Instantiate(SeaMine, position, rotation);}
        	else{Instantiate(Treasure, position, rotation);}
        }
    }
}
