using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDestroyer : MonoBehaviour
{
	[SerializeField]
    Tilemap FGMap;
    [SerializeField]
    Vector3Int currentCell;
    bool createFloor = true;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float FGpos = FGMap.transform.position.x;
    	int FGpos_i = (int) FGpos;
    	float FGposDelta = FGpos-FGpos_i;
    	
    	if(FGposDelta<-0.9){
    		if(createFloor==true){
    			currentCell.x +=1;
    			for(int i = 0; i < 30; i++){
    				Vector3Int cy = currentCell;
		    		cy.y =currentCell.y-i;
    				FGMap.SetTile(cy, null);
    			}
    		}
    		createFloor=false;
    	}
    	else{createFloor=true;}
    }
}
