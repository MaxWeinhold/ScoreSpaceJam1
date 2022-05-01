using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointUI : MonoBehaviour
{
    void Update()
    {
        int points = PlayerPrefs.GetInt("Points");
        GetComponent<Text>().text = points.ToString()  + "P";
    }
}
