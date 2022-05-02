using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateLeaderboard : MonoBehaviour
{
	//GameObject lb;
	[SerializeField]Leaderboard leaderboard;
	
    void Start()
    {
//    	lb = GameObject.Find("Leaderboard");
//        leaderboard = lb.GetComponent<Leaderboard>();
    }

    void OnEnable()
    {
        StartCoroutine("LeaderboardUpdate", 1.0f);
    }
    
    IEnumerator LeaderboardUpdate(){
    	yield return leaderboard.FetchTopHighscoresRoutine();
    }
}
