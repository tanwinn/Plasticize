using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnTrigger : MonoBehaviour {
    public GameObject soundObject;
    public Collider triggerObjectCollider;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Collider>() == triggerObjectCollider) {
            Debug.Log(gameObject + " colliders with " + other.gameObject.tag);
            soundObject.SetActive(true);
        }   
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.GetComponent<Collider>() == triggerObjectCollider) {
            Debug.Log(gameObject + " colliders with " + other.gameObject.tag);
            soundObject.SetActive(false);
        }
    }
}
