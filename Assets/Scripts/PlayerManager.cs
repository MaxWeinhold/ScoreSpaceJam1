using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
	GameObject lb;
	Leaderboard leaderboard;
	[SerializeField] Text playerNameInputfield;
	
    void Start()
    {
        lb = GameObject.Find("Leaderboard");
        leaderboard = lb.GetComponent<Leaderboard>();
        
    	StartCoroutine(SetupRoutine());
    }
    
    public void SetPlayerName(){
    	LootLockerSDKManager.SetPlayerName(playerNameInputfield.text, (response)=>{
    		if(response.success){
    	    	Debug.Log("Successfully set player name");
    	    }
    	    else{
    	    	Debug.Log("Could not set player name"+response.Error);
    	    }
		});
    }
    
    IEnumerator SetupRoutine(){
    	yield return LoginRoutine();
    	yield return leaderboard.FetchTopHighscoresRoutine();
    }
    
    IEnumerator LoginRoutine(){
    	bool done=false;
    	LootLockerSDKManager.StartGuestSession((response) =>
    	{
    		if(response.success){
    	    	Debug.Log("Player was logged in");
    	    	PlayerPrefs.SetString("PlayerID",response.player_id.ToString());
    	    	done = true;
    	    }
    	    else{
    	    	Debug.Log("Could not start session");
    	    	done = true;
    	    }
    	});
    	yield return new WaitWhile(() => done == false);
    }
}
