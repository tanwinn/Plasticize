using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDetector : MonoBehaviour {

    [Tooltip("Numbers of trash the user needs to put in the trash can before the scene changes")]
    public int trashMustBeInCounter = 2;

    [Tooltip("Delay time before the scene changes")]
    public float animationDelaySeconds = 7f;

    [Tooltip("Delay time before start detecting trash in the trash can")]
    public float trashDetectorDelaySeconds = 7f;

    [HideInInspector]
    public bool sceneChangeTrigger = false;

    int trashInCounter = 0;
    float animationTimer = 0f;
    float trashDetectorTimer = 0f;
    List<Collider> Trashes = new List<Collider>();

    private void Start() {
        Debug.Log("Collider of " + gameObject.name + " is disabled");
        gameObject.GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update () {
        trashDetectorTimer += Time.deltaTime;

        if (trashDetectorTimer >= trashDetectorDelaySeconds && !gameObject.GetComponent<Collider>().enabled) {
            gameObject.GetComponent<Collider>().enabled = true;
            Debug.Log("Collider of " + gameObject.name + " is enabled");
        }
        
        if (trashInCounter >= trashMustBeInCounter) {
            Debug.Log("Triggers scene changing. Delay seconds left: " + (animationDelaySeconds - animationTimer));
            animationTimer += Time.deltaTime;
        }

        // Start Count Down the changing scene action
        if (animationTimer >= animationDelaySeconds && !sceneChangeTrigger) {
            sceneChangeTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        // check if other is already contained in Trash list, which can be identified through its name attribute
        if (Trashes.Find(x => x.GetInstanceID() == other.GetInstanceID()) == null)
            if (other.tag == "trash") {
                Trashes.Add(other);
                Debug.Log("Trash is put in the can: " + other.name);
                trashInCounter++;
            }

    }
}
