using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickOnTheGround : MonoBehaviour {
    public GameObject rig;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(rig.transform.position.x, 0.015f, rig.transform.position.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, rig.transform.eulerAngles.y, transform.eulerAngles.z);
		
	}
}
