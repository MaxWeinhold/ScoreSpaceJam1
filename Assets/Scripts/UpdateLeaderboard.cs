using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateLeaderboard : MonoBehaviour
{
	GameObject lb;
	Leaderboard leaderboard;
	
    // Start is called before the first frame update
    void Start()
    {
    	lb = GameObject.Find("Leaderboard");
        leaderboard = lb.GetComponent<Leaderboard>();
    }

    void OnEnable()
    {
        StartCoroutine("LeaderboardUpdate", 1.0f);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator LeaderboardUpdate(){
    	yield return leaderboard.FetchTopHighscoresRoutine();
    }
}
