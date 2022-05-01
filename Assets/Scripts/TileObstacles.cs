using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileObstacles : MonoBehaviour
{
	GameObject submarine;
	Player player;
	
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
	float cooldown = 0;
	float timer = 0;
	
	[Header("TileMap Adjustments")]
	[SerializeField]
	Tile Floor1;
	[SerializeField]
	Tile [] TileChunkA;
	[SerializeField]
    Tilemap FGMap;
    [SerializeField]
    Vector3Int currentCell;
    bool createFloor = true;
    bool now_obstacle = false;
	
    // Start is called before the first frame update
    void Start()
    {
		submarine = GameObject.Find("Submarine");
        player = submarine.GetComponent<Player>();
        FGMap.SetTile(currentCell, Floor1);
    }

    // Update is called once per frame
    void Update()
    {
    	float FGpos = FGMap.transform.position.x;
    	int FGpos_i = (int) FGpos;
    	float FGposDelta = FGpos-FGpos_i;
    	
    	if(FGposDelta<-0.5){
    		if(createFloor==true){
    			Vector3Int Cell = currentCell;
    			Cell.x +=1;
    			if(FGMap.HasTile(Cell)==false && now_obstacle == true){
    				Vector3Int C = currentCell;
    				int r2 = Random.Range(-2, 6);
    				C.y +=r2;
    				for (int i = 0; i < TileChunkA.Length; i++){
    					Vector3Int c = C;
    					c.x +=i;
    					FGMap.SetTile(c, TileChunkA[i]);
    				}
    				//FGMap.SetTile(C, Floor1);
    				now_obstacle = false;
    			}
    			currentCell.x +=1;
    		}
    		createFloor=false;
    	}
    	else{createFloor=true;}
    	
        if(player.playing){
	        timer += Time.deltaTime;
	        
	        // for the start take the start_time as cooldown
	        if(cooldown==0){
	        	cooldown=start_time;
	        }
	        
	        //cooldown is down, next prefab will be spawned
	        if(timer>cooldown){
	        	// set up the next cooldown time randomly
	        	timer=0;
	        	float r = Random.Range(minimum_time, maximum_time);
	        	cooldown = r/PlayerPrefs.GetFloat("TimeSpped");//TimeSpeed will increase the pacing by time
	        	
	        	now_obstacle = true;
	        }
	    }
    	else{
    		//Reset for game restarting
    		timer=0;
    		cooldown=0;
    		FGMap.ClearAllTiles();
    	}
    }
}
