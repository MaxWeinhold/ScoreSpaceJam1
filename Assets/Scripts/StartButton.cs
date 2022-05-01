using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
	int clicks;
	GameObject submarine;
	Player player;
	
	[SerializeField] GameObject Panel1;
	[SerializeField] GameObject Panel2;
	[SerializeField] GameObject Frame;
	
	
    // Start is called before the first frame update
    void Start()
    {
        clicks = 0;
        submarine = GameObject.Find("Submarine");
        player = submarine.GetComponent<Player>();
    	Panel2.SetActive(false);
        Frame.SetActive(true);
        Panel1.SetActive(true);
    }
    
    public void BottonClicked () {
    
    	if(clicks==0){
    		clicks++;
    		Panel1.SetActive(false);
    		Panel2.SetActive(true);
    	}
    	else if(clicks==1){
    		player.playing=true;
    		Frame.SetActive(false);
    	}
    }
}
