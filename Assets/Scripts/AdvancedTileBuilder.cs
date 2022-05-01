using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AdvancedTileBuilder : MonoBehaviour
{
//	[SerializeField]
//	Tile Floor1;
	[SerializeField]
    Tilemap FGMap;
    [SerializeField]
    Vector3Int currentCell;
	
	
	[SerializeField]
	[Range(1, 12)]
	int levels = 1;
	
	[SerializeField]
	bool randomGeneration = false;
	[SerializeField]
	[Range(2, 7)]
	int randomNumbers = 2;
	
	[SerializeField]
	Tile [] TileChunkA;
	[SerializeField]
	Tile [] TileChunkA2;
	[SerializeField]
	Tile [] TileChunkA3;
	[SerializeField]
	Tile [] TileChunkA4;
	[SerializeField]
	Tile [] TileChunkA5;
	[SerializeField]
	Tile [] TileChunkA6;
	[SerializeField]
	Tile [] TileChunkA7;
	[SerializeField]
	Tile [] TileChunkA8;
	[SerializeField]
	Tile [] TileChunkA9;
	[SerializeField]
	Tile [] TileChunkA10;
	[SerializeField]
	Tile [] TileChunkA11;
	[SerializeField]
	Tile [] TileChunkA12;
	
	[SerializeField]
	Tile [] TileChunkB;
	[SerializeField]
	Tile [] TileChunkB2;
	[SerializeField]
	Tile [] TileChunkB3;
	[SerializeField]
	Tile [] TileChunkB4;
	[SerializeField]
	Tile [] TileChunkB5;
	[SerializeField]
	Tile [] TileChunkB6;
	[SerializeField]
	Tile [] TileChunkB7;
	[SerializeField]
	Tile [] TileChunkB8;
	[SerializeField]
	Tile [] TileChunkB9;
	[SerializeField]
	Tile [] TileChunkB10;
	[SerializeField]
	Tile [] TileChunkB11;
	[SerializeField]
	Tile [] TileChunkB12;
	
	[SerializeField]
	Tile [] TileChunkC;
	[SerializeField]
	Tile [] TileChunkC2;
	[SerializeField]
	Tile [] TileChunkC3;
	[SerializeField]
	Tile [] TileChunkC4;
	[SerializeField]
	Tile [] TileChunkC5;
	[SerializeField]
	Tile [] TileChunkC6;
	[SerializeField]
	Tile [] TileChunkC7;
	[SerializeField]
	Tile [] TileChunkC8;
	[SerializeField]
	Tile [] TileChunkC9;
	[SerializeField]
	Tile [] TileChunkC10;
	[SerializeField]
	Tile [] TileChunkC11;
	[SerializeField]
	Tile [] TileChunkC12;
	
	[SerializeField]
	Tile [] TileChunkD;
	[SerializeField]
	Tile [] TileChunkD2;
	[SerializeField]
	Tile [] TileChunkD3;
	[SerializeField]
	Tile [] TileChunkD4;
	[SerializeField]
	Tile [] TileChunkD5;
	[SerializeField]
	Tile [] TileChunkD6;
	[SerializeField]
	Tile [] TileChunkD7;
	[SerializeField]
	Tile [] TileChunkD8;
	[SerializeField]
	Tile [] TileChunkD9;
	[SerializeField]
	Tile [] TileChunkD10;
	[SerializeField]
	Tile [] TileChunkD11;
	[SerializeField]
	Tile [] TileChunkD12;
	
	[SerializeField]
	Tile [] TileChunkE;
	[SerializeField]
	Tile [] TileChunkE2;
	[SerializeField]
	Tile [] TileChunkE3;
	[SerializeField]
	Tile [] TileChunkE4;
	[SerializeField]
	Tile [] TileChunkE5;
	[SerializeField]
	Tile [] TileChunkE6;
	[SerializeField]
	Tile [] TileChunkE7;
	[SerializeField]
	Tile [] TileChunkE8;
	[SerializeField]
	Tile [] TileChunkE9;
	[SerializeField]
	Tile [] TileChunkE10;
	[SerializeField]
	Tile [] TileChunkE11;
	[SerializeField]
	Tile [] TileChunkE12;
	
	[SerializeField]
	Tile [] TileChunkF;
	[SerializeField]
	Tile [] TileChunkF2;
	[SerializeField]
	Tile [] TileChunkF3;
	[SerializeField]
	Tile [] TileChunkF4;
	[SerializeField]
	Tile [] TileChunkF5;
	[SerializeField]
	Tile [] TileChunkF6;
	[SerializeField]
	Tile [] TileChunkF7;
	[SerializeField]
	Tile [] TileChunkF8;
	[SerializeField]
	Tile [] TileChunkF9;
	[SerializeField]
	Tile [] TileChunkF10;
	[SerializeField]
	Tile [] TileChunkF11;
	[SerializeField]
	Tile [] TileChunkF12;
	
	
	
    bool createFloor = true;
	
    // Start is called before the first frame update
    void Start()
    {
        //FGMap.SetTile(currentCell, Floor1);
    }

    // Update is called once per frame
    void Update()
    {
        float FGpos = FGMap.transform.position.x;
    	int FGpos_i = (int) FGpos;
    	float FGposDelta = FGpos-FGpos_i;
    	
    	//print(FGposDelta);
    	
    	if(FGposDelta<-0.5){
    		if(createFloor==true){
    			Vector3Int Cell = currentCell;
    			//Cell.x +=1;
    			
    			bool anytiles=false;
    			for(int i = 0; i < levels; i++){
    				Vector3Int cyt = Cell;
		    		cyt.y =Cell.y-i;
		    		if(FGMap.HasTile(cyt)==true){anytiles=true;}
    			}
    			
    			if(anytiles==false){
    				
    				if(randomGeneration==true){
    					//Random rnd = new Random();
						//int r  = rnd.Next(1, randomNumbers);
						int r = Random.Range(1, randomNumbers);
						if(r==1){
							for (int i = 0; i < TileChunkA.Length; i++){
			    				Vector3Int c = currentCell;
			    				c.x +=i;
			    				for(int j = 0; j < levels; j++){
			    					Vector3Int cy = c;
			    					cy.y =c.y-j;
			    					if(j==0){FGMap.SetTile(cy, TileChunkA[i]);}
			    					if(j==1){FGMap.SetTile(cy, TileChunkA2[i]);}
			    					if(j==2){FGMap.SetTile(cy, TileChunkA3[i]);}
			    					if(j==3){FGMap.SetTile(cy, TileChunkA4[i]);}
			    					if(j==4){FGMap.SetTile(cy, TileChunkA5[i]);}
			    					if(j==5){FGMap.SetTile(cy, TileChunkA6[i]);}
			    					if(j==6){FGMap.SetTile(cy, TileChunkA7[i]);}
			    					if(j==7){FGMap.SetTile(cy, TileChunkA8[i]);}
			    					if(j==8){FGMap.SetTile(cy, TileChunkA9[i]);}
			    					if(j==9){FGMap.SetTile(cy, TileChunkA10[i]);}
			    					if(j==10){FGMap.SetTile(cy, TileChunkA11[i]);}
			    					if(j==11){FGMap.SetTile(cy, TileChunkA12[i]);}
			    				}
			    			}
						}
						else if(r==2){
							for (int i = 0; i < TileChunkB.Length; i++){
			    				Vector3Int c = currentCell;
			    				c.x +=i;
			    				for(int j = 0; j < levels; j++){
			    					Vector3Int cy = c;
			    					cy.y =c.y-j;
			    					if(j==0){FGMap.SetTile(cy, TileChunkB[i]);}
			    					if(j==1){FGMap.SetTile(cy, TileChunkB2[i]);}
			    					if(j==2){FGMap.SetTile(cy, TileChunkB3[i]);}
			    					if(j==3){FGMap.SetTile(cy, TileChunkB4[i]);}
			    					if(j==4){FGMap.SetTile(cy, TileChunkB5[i]);}
			    					if(j==5){FGMap.SetTile(cy, TileChunkB6[i]);}
			    					if(j==6){FGMap.SetTile(cy, TileChunkB7[i]);}
			    					if(j==7){FGMap.SetTile(cy, TileChunkB8[i]);}
			    					if(j==8){FGMap.SetTile(cy, TileChunkB9[i]);}
			    					if(j==9){FGMap.SetTile(cy, TileChunkB10[i]);}
			    					if(j==10){FGMap.SetTile(cy, TileChunkB11[i]);}
			    					if(j==11){FGMap.SetTile(cy, TileChunkB12[i]);}
			    				}
			    			}
						}
						else if(r==3){
							for (int i = 0; i < TileChunkC.Length; i++){
			    				Vector3Int c = currentCell;
			    				c.x +=i;
			    				for(int j = 0; j < levels; j++){
			    					Vector3Int cy = c;
			    					cy.y =c.y-j;
			    					if(j==0){FGMap.SetTile(cy, TileChunkC[i]);}
			    					if(j==1){FGMap.SetTile(cy, TileChunkC2[i]);}
			    					if(j==2){FGMap.SetTile(cy, TileChunkC3[i]);}
			    					if(j==3){FGMap.SetTile(cy, TileChunkC4[i]);}
			    					if(j==4){FGMap.SetTile(cy, TileChunkC5[i]);}
			    					if(j==5){FGMap.SetTile(cy, TileChunkC6[i]);}
			    					if(j==6){FGMap.SetTile(cy, TileChunkC7[i]);}
			    					if(j==7){FGMap.SetTile(cy, TileChunkC8[i]);}
			    					if(j==8){FGMap.SetTile(cy, TileChunkC9[i]);}
			    					if(j==9){FGMap.SetTile(cy, TileChunkC10[i]);}
			    					if(j==10){FGMap.SetTile(cy, TileChunkC11[i]);}
			    					if(j==11){FGMap.SetTile(cy, TileChunkC12[i]);}
			    				}
			    			}
						}
						else if(r==4){
							for (int i = 0; i < TileChunkD.Length; i++){
			    				Vector3Int c = currentCell;
			    				c.x +=i;
			    				for(int j = 0; j < levels; j++){
			    					Vector3Int cy = c;
			    					cy.y =c.y-j;
			    					if(j==0){FGMap.SetTile(cy, TileChunkD[i]);}
			    					if(j==1){FGMap.SetTile(cy, TileChunkD2[i]);}
			    					if(j==2){FGMap.SetTile(cy, TileChunkD3[i]);}
			    					if(j==3){FGMap.SetTile(cy, TileChunkD4[i]);}
			    					if(j==4){FGMap.SetTile(cy, TileChunkD5[i]);}
			    					if(j==5){FGMap.SetTile(cy, TileChunkD6[i]);}
			    					if(j==6){FGMap.SetTile(cy, TileChunkD7[i]);}
			    					if(j==7){FGMap.SetTile(cy, TileChunkD8[i]);}
			    					if(j==8){FGMap.SetTile(cy, TileChunkD9[i]);}
			    					if(j==9){FGMap.SetTile(cy, TileChunkD10[i]);}
			    					if(j==10){FGMap.SetTile(cy, TileChunkD11[i]);}
			    					if(j==11){FGMap.SetTile(cy, TileChunkD12[i]);}
			    				}
			    			}
						}
						else if(r==5){
							for (int i = 0; i < TileChunkE.Length; i++){
			    				Vector3Int c = currentCell;
			    				c.x +=i;
			    				for(int j = 0; j < levels; j++){
			    					Vector3Int cy = c;
			    					cy.y =c.y-j;
			    					if(j==0){FGMap.SetTile(cy, TileChunkE[i]);}
			    					if(j==1){FGMap.SetTile(cy, TileChunkE2[i]);}
			    					if(j==2){FGMap.SetTile(cy, TileChunkE3[i]);}
			    					if(j==3){FGMap.SetTile(cy, TileChunkE4[i]);}
			    					if(j==4){FGMap.SetTile(cy, TileChunkE5[i]);}
			    					if(j==5){FGMap.SetTile(cy, TileChunkE6[i]);}
			    					if(j==6){FGMap.SetTile(cy, TileChunkE7[i]);}
			    					if(j==7){FGMap.SetTile(cy, TileChunkE8[i]);}
			    					if(j==8){FGMap.SetTile(cy, TileChunkE9[i]);}
			    					if(j==9){FGMap.SetTile(cy, TileChunkE10[i]);}
			    					if(j==10){FGMap.SetTile(cy, TileChunkE11[i]);}
			    					if(j==11){FGMap.SetTile(cy, TileChunkE12[i]);}
			    				}
			    			}
						}
						else if(r==6){
							for (int i = 0; i < TileChunkF.Length; i++){
			    				Vector3Int c = currentCell;
			    				c.x +=i;
			    				for(int j = 0; j < levels; j++){
			    					Vector3Int cy = c;
			    					cy.y =c.y-j;
			    					if(j==0){FGMap.SetTile(cy, TileChunkF[i]);}
			    					if(j==1){FGMap.SetTile(cy, TileChunkF2[i]);}
			    					if(j==2){FGMap.SetTile(cy, TileChunkF3[i]);}
			    					if(j==3){FGMap.SetTile(cy, TileChunkF4[i]);}
			    					if(j==4){FGMap.SetTile(cy, TileChunkF5[i]);}
			    					if(j==5){FGMap.SetTile(cy, TileChunkF6[i]);}
			    					if(j==6){FGMap.SetTile(cy, TileChunkF7[i]);}
			    					if(j==7){FGMap.SetTile(cy, TileChunkF8[i]);}
			    					if(j==8){FGMap.SetTile(cy, TileChunkF9[i]);}
			    					if(j==9){FGMap.SetTile(cy, TileChunkF10[i]);}
			    					if(j==10){FGMap.SetTile(cy, TileChunkF11[i]);}
			    					if(j==11){FGMap.SetTile(cy, TileChunkF12[i]);}
			    				}
			    			}
						}
    				}
    				else{
	    				
    					
    					
    						
    					for (int i = 0; i < TileChunkA.Length; i++){
		    				Vector3Int c = currentCell;
		    				c.x +=i;
		    				for(int j = 0; j < levels; j++){
		    					Vector3Int cy = c;
		    					cy.y =c.y-j;
		    					if(j==0){FGMap.SetTile(cy, TileChunkA[i]);}
		    					if(j==1){FGMap.SetTile(cy, TileChunkA2[i]);}
		    					if(j==2){FGMap.SetTile(cy, TileChunkA3[i]);}
		    					if(j==3){FGMap.SetTile(cy, TileChunkA4[i]);}
		    					if(j==4){FGMap.SetTile(cy, TileChunkA5[i]);}
		    					if(j==5){FGMap.SetTile(cy, TileChunkA6[i]);}
		    					if(j==6){FGMap.SetTile(cy, TileChunkA7[i]);}
		    					if(j==7){FGMap.SetTile(cy, TileChunkA8[i]);}
		    					if(j==8){FGMap.SetTile(cy, TileChunkA9[i]);}
		    					if(j==9){FGMap.SetTile(cy, TileChunkA10[i]);}
		    					if(j==10){FGMap.SetTile(cy, TileChunkA11[i]);}
		    					if(j==11){FGMap.SetTile(cy, TileChunkA12[i]);}
		    				}
		    			}
		    			
    					
    					
    					
	    				
    				
	    				
	    				
    				}
    			}
    			currentCell.x += 1;
    		}
    		createFloor=false;
    	}
    	else{createFloor=true;}
    }
}
