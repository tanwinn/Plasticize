using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearAfterSeconds : MonoBehaviour {

    public float DelayTime = 10f;
    float timer = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= DelayTime && gameObject.GetComponent<BoxCollider>() != null) {
            Destroy(gameObject.GetComponent<BoxCollider>());
            Debug.Log("Destroyed BoxCollider of Cover");
        }            
	}
}
