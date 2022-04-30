using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{   
    private Vector3 _startPosition;
    [Range(1f, 35f)]
    [SerializeField] float frequency=4;
    [Range(1f, 250f)]
    [SerializeField] float amplitude=4;
	

    // Update is called once per frame
    void Update()
    {
        _startPosition = transform.position;
	    transform.position = _startPosition + new Vector3(0.0f, 0.0005f*amplitude*Mathf.Sin(frequency*Time.time), 0.0f);
    }
}
