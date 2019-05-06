using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGestureCommand : MonoBehaviour {

    public FPSController controller;
    public List<GameObject> gameObjectManager;
    private bool status = false;

    public AudioSource playSound;
    public float delaySec = 2f;

	// Use this for initialization
	void Start () {
        setStatus();
        if (playSound!=null) playSound.PlayDelayed(delaySec);

	}

    void setStatus() {
        controller.enabled = status;
        foreach (GameObject go in gameObjectManager) {
            go.SetActive(status);
        }
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space")) {
            Debug.Log("space is Pressed");
            status = !status;
            setStatus();
        }
	}
}
