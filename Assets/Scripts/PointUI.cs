using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int points = PlayerPrefs.GetInt("Points");
        
        GetComponent<Text>().text = points.ToString()  + "P";
    }
}
