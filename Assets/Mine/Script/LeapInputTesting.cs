using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SeniorIS.CrossPlatformInput;
using Leap.Unity;

public class LeapInputTesting : MonoBehaviour {
    public Detector forwardDetector;
    public Detector backwardDetector;
    public List<Gesture> gm;

    void CreateGestureManager() {
        gm = new List<Gesture>();
        Gesture forwardGesture = new Gesture(forwardDetector, "Vertical");
        gm.Add(forwardGesture);
        Gesture backwardGesture = new Gesture(backwardDetector, "Verical", -1f);
        gm.Add(backwardGesture);
    }

    private void OnEnable() {
        CreateDetector();
        CreateGestureManager();
    }

    void CreateDetector() {
        //forwardDetector = new ExtendedFingerDetector();
        //backwardDetector = new ExtendedFingerDetector();
        forwardDetector = GetComponent<ExtendedFingerDetector>();
        backwardDetector = GetComponent<DetectorLogicGate>();
    }

	// Use this for initialization
	void Start () {
        CreateGestureManager();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
