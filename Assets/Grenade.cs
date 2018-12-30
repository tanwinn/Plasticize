using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void printInfo() {
        Debug.Log(this);
        print("Deactivated");
    }

    public void DestroyImmediately() {
        Destroy(this.gameObject);
    }

    // Function Called by On Grasp End
    public void StartDestroyCountDown() {
        Debug.Log("DestroyImmediate is called");
        Invoke("DestroyImmediately", 3);
    }
}
