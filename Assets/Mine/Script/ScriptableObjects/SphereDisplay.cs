using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDisplay : MonoBehaviour {
    public Sphere sphere;
    // Keeps track of the change for ome-time update
    private bool ObjectisModified = false;
    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().material = sphere.material;
        name = sphere.name;
        transform.localScale = new Vector3(sphere.size, sphere.size, sphere.size);
        if (sphere.isInteractive)
            gameObject.AddComponent<Leap.Unity.Interaction.InteractionBehaviour>();
        else
            gameObject.AddComponent<Rigidbody>();
    }

    // Keeps track of the change for ome-time update
    private bool ObjectIsModified = false;

    public void setIsInteractive(bool input) {
        sphere.isInteractive = input;
        ObjectIsModified = true;
    }

    void Update() {
        if (ObjectIsModified) {
            if (sphere.isInteractive) {
                gameObject.AddComponent<Leap.Unity.Interaction.InteractionBehaviour>();
            }
            else if (gameObject.GetComponent<Leap.Unity.Interaction.InteractionBehaviour>()) {
                //Debug.Log("Destroy Interaction Behaviour");
                Destroy(gameObject.GetComponent<Leap.Unity.Interaction.InteractionBehaviour>());
                if (gameObject.GetComponent<Rigidbody>() == null)
                    gameObject.AddComponent<Rigidbody>();
            }
            ObjectIsModified = false;
        }
    }
}
