using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
	GameObject submarine;
	Player player;
	[SerializeField] GameObject Frame;
	
    // Start is called before the first frame update
    void Start()
    {
        submarine = GameObject.Find("Submarine");
        player = submarine.GetComponent<Player>();
        
    }

    public void BottonClicked () {
    	
    	PlayerPrefs.SetInt("Points",0);
    	player.dead=false;
    	player.playing=true;
    	Frame.SetActive(false);
    }
}
