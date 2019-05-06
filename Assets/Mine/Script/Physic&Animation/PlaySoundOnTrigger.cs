using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnTrigger : MonoBehaviour {
    public GameObject soundObject;
    public Collider triggerObjectCollider;

    AudioSource source;

    private void Start() {
        source = soundObject.GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.GetComponent<Collider>() == triggerObjectCollider) {
            //Debug.Log(gameObject + " colliders with " + other.gameObject.tag);
            if (!soundObject.activeSelf) soundObject.SetActive(true);
        }   
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.GetComponent<Collider>() == triggerObjectCollider) {
            Debug.Log(gameObject + " colliders with " + other.gameObject.tag);
            if (soundObject.activeSelf) soundObject.SetActive(false);
        }
    }
}
