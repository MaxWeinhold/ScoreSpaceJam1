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
    	//currentCell = FGMap.WorldToCell(transform.position);
    	//print(FGMap.HasTile(currentCell));
        FGMap.SetTile(currentCell, Floor1);
        //print(currentCell);
    }

    // Update is called once per frame
    void Update()
    {
    	float FGpos = FGMap.transform.position.x;
    	int FGpos_i = (int) FGpos;
    	float FGposDelta = FGpos-FGpos_i;
    	
    	//print(FGposDelta);
    	
    	if(FGposDelta<-0.9){
    		if(createFloor==true){
    			Vector3Int Cell = currentCell;
    			Cell.x +=1;
    			print(FGMap.HasTile(Cell));
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
