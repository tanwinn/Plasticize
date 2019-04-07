using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class DestroyNonInteractive : MonoBehaviour {

    private void OnTriggerEnter(Collider collision) {
        //Debug.Log(collision.gameObject.name + " has tag " + collision.gameObject.tag);
        if (collision.gameObject.tag == "trash"){
            InteractionBehaviour interactive = collision.gameObject.GetComponent<InteractionBehaviour>() as InteractionBehaviour;
            //Debug.Log(interactive);
            if (interactive == null) {
                collision.gameObject.AddComponent<InteractionBehaviour>();
                //Debug.Log("Add Interaction");
            }
        }
    }
}
