using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDetector : MonoBehaviour {

    [Header("Trash detector")]

    [Tooltip("Numbers of trash the user needs to put in the trash can before the trigger events changes")]
    public int trashMustBeInCounter = 2;

    [Tooltip("Delay time before start detecting trash in the trash can")]
    public float trashDetectorDelaySeconds = 7f;

    [Header("Event triggers")]
    [Tooltip("Does this detector trigger scene changing?")]
    public bool sceneChangingEvent = false;

    [Tooltip("Delay time before the scene changes")][ConditionalHide("sceneChangingEvent")]
    public float sceneChangingDelaySeconds = 7f;

    [Tooltip("Does this detector trigger trash spawner?")]
    public bool trashSpawnerEvent = false;

    [Tooltip("Doestroy object after colliding?")]
    public bool destroyAfterColliding = false;
    
    //[Tooltip("Delay time before object spawner active")]
    //[ConditionalHide("trashSpawnerEvent")]
    //public float trashSpawnerDelaySeconds = .1f;

    [HideInInspector]
    public bool sceneChangeTrigger = false;
    [HideInInspector]
    public bool trashSpawnerTrigger = false;
    [HideInInspector]
    public int trashInCounter = 0;
    

    float animationTimer = 0f;
    float trashSpawnerTimer = 0f;
    float trashDetectorTimer = 0f;
    List<Collider> Trashes = new List<Collider>();

    bool DEBUG_MODE = false;

    bool didOnce = false;

    private void Start() {
        if (trashSpawnerEvent) {
            trashInCounter = trashMustBeInCounter;
        }
        Debug.Log("Detector " + gameObject.name + " is disabled");
        //gameObject.GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update () {
        trashDetectorTimer += Time.deltaTime;

        if (trashDetectorTimer >= trashDetectorDelaySeconds && !didOnce) {//gameObject.GetComponent<Collider>().enabled) {
            //gameObject.GetComponent<Collider>().enabled = true;
            didOnce = !didOnce;
            Debug.Log("Detector " + gameObject.name + " is enabled");
        }

        if (trashInCounter >= trashMustBeInCounter) {
            if (sceneChangingEvent) {
                Debug.Log("Triggers scene changing. Delay seconds left: " + (sceneChangingDelaySeconds - animationTimer));
                animationTimer += Time.deltaTime;
            }

            if (trashSpawnerEvent) {
                Debug.Log("Triggers spawning event");
                trashSpawnerTrigger = true;
                if (DEBUG_MODE) Debug.Log("trashInCounter :" + trashInCounter);
            }
        }

        // Start Count Down the changing scene action
        if (animationTimer >= sceneChangingDelaySeconds && !sceneChangeTrigger) {
            sceneChangeTrigger = true;
            animationTimer = 0f;
            trashInCounter = 0;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (trashDetectorTimer < trashDetectorDelaySeconds) {
            if (other.tag == "trash") {
                Destroy(other.gameObject);
                Debug.Log("Destroy");
            }
        }
        // check if other is already contained in Trash list, which can be identified through its name attribute
        else if (Trashes.Find(x => x.GetInstanceID() == other.GetInstanceID()) == null)
            if (other.tag == "trash") {
                Trashes.Add(other);
                if (DEBUG_MODE) Debug.Log("Trash is put in the can: " + other.name);
                trashInCounter++;

                // destroy collider after colliding
                if (destroyAfterColliding) {
                    Destroy(other.gameObject);
                    if (DEBUG_MODE) Debug.Log("Destroy game object after colliding");
                }

            }

    }
}
