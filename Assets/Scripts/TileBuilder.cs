using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TileBuilder : MonoBehaviour
{
	[SerializeField]
	Tile Floor1;
	[SerializeField]
    Tilemap FGMap;
    [SerializeField]
    Vector3Int currentCell;
    bool createFloor = true;
	
    // Start is called before the first frame update
    void Start()
    {
        FGMap.SetTile(currentCell, Floor1);
    }

    void Update()
    {
    	float FGpos = FGMap.transform.position.x;
    	int FGpos_i = (int) FGpos;
    	float FGposDelta = FGpos-FGpos_i;
    	
    	if(FGposDelta<-0.5){
    		if(createFloor==true){
    			Vector3Int Cell = currentCell;
    			Cell.x +=1;
    			if(FGMap.HasTile(Cell)==false){
    				currentCell.x +=1;
    				FGMap.SetTile(currentCell, Floor1);
    			}
    		}
    		createFloor=false;
    	}
    	else{createFloor=true;}
    }
}
