using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

[RequireComponent(typeof(ExtendedFingerDetector))]
[RequireComponent(typeof(PalmDirectionDetector))]
public class RotateCommandRecognition : MonoBehaviour {

    private ExtendedFingerDetector extendedFingerDetect;
    private PalmDirectionDetector palmDirectionDetect;
    [SerializeField]
    private PinchDetector pinchDetect;
    [SerializeField]
    private FingerDirectionDetector thumbLeftDetect;
    [SerializeField]
    private FingerDirectionDetector thumbRightDetect;
    [SerializeField]
    private FingerDirectionDetector indexDirectionDetect;
    [SerializeField]
    private GameObject indexFinger;
    [HideInInspector]
    public bool isActive = false;

    private GameObject parent;
    private GameObject camera; 
    Vector3 pinchStartPosition;
    float speed = 20f;
    
	// Use this for initialization
	void Start () {
        parent = transform.root.gameObject;
        extendedFingerDetect = GetComponent<ExtendedFingerDetector>();
        palmDirectionDetect = GetComponent<PalmDirectionDetector>();
        if (thumbLeftDetect == null || indexDirectionDetect == null)
            Debug.LogError("Finger direction detectors = NULL");
        Debug.Log("Parent: " + parent.name);
	}
	
    private bool perfectLShapeGesture() {
        float dotProduct = Vector3.Dot(thumbLeftDetect.PointingDirection, indexDirectionDetect.PointingDirection);
        if (0f <=Mathf.Abs(dotProduct) && Mathf.Abs(dotProduct) <= 5f){
            return true;
        }
        return true;
    }

	// Update is called once per frame
	void Update () {
        // update parent accordingly to camera
    }

    void RotateToPinch() {
        if (pinchDetect.IsActive) {
            pinchDetect.name = "pinch active";
            if (pinchDetect.DidStartPinch) {
                Debug.Log("DidStartPinch: " + pinchDetect.DidStartPinch);
                pinchStartPosition = pinchDetect.Position;
            }
            else {
                float rotation = pinchDetect.Position.z - pinchStartPosition.z;
                Debug.Log("Rotation: " + rotation);
                //Vector3 rotation = ((pinchDetect.Position.z - pinchDetect.LastActivePosition.z) * transform.forward + (pinchDetect.Position.x - pinchDetect.LastActivePosition.x) * transform.right).normalized;
                //parent.transform.Rotate(0, rotation.z * Time.deltaTime * speed, 0);
                parent.transform.Rotate(0, rotation, 0);
                pinchStartPosition = pinchDetect.Position;
            }
        }
        else
            pinchDetect.name = "pinch deactive";
    }

    
    void RotateView() {
        //if (palmDirectionDetect.IsActive)
        //    parent.transform.Rotate(0, palmDirectionDetect.PointingDirection.x * 10f * Time.deltaTime, 0);
        //else
        //    parent.transform.Rotate(0, - palmDirectionDetect.PointingDirection.x * 10f * Time.deltaTime, 0);
        // Offset angle from camera diretction to finger pointing
        //float offset = FindObjectOfType<Camera>().transform.localEulerAngles.y - indexDirectionDetect.PointingDirection.x;
        //Vector3 currentAngle = parent.transform.localEulerAngles;
        Debug.Log("absolute: "+Mathf.Abs(indexFinger.transform.localEulerAngles.y));
        if (Mathf.Abs(indexFinger.transform.localEulerAngles.y) >= 180) {
            Debug.Log("Positive");
            parent.transform.Rotate(0, speed * Time.deltaTime, 0);
        }
        else {
            Debug.Log("Negative");
            parent.transform.Rotate(0, -speed * Time.deltaTime, 0);
        }
        //Vector3 offset = ToVector3(indexFinger.GetLeapFinger().Direction);

        //Debug.Log("PointingDirection.z: " + offset);
        //rent.transform.SetLocalY(indexDirectionDetect.PointingDirection.z * Time.deltaTime);
        //Debug.Log(palmDirectionDetect.PointingDirection);
    }

    private void FixedUpdate() {
        //RotateToPinch();
        isActive = (perfectLShapeGesture() && extendedFingerDetect.IsActive);
        if (isActive) {
            gameObject.name = "activate Rotate Gesture";
            RotateView();
            //RotateToPinch();
        }
        else
            gameObject.name = "deactivate Rotate Gesture";
    }

}



