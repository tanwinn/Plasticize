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
        // default for now, when generate, can randomize position and rotation
        transform.localPosition = sphere.position;
        if (sphere.isInteractive)
            gameObject.AddComponent<Leap.Unity.Interaction.InteractionBehaviour>();
    }

    public void setPosition(Vector3 input) {
        sphere.position = input;
        ObjectisModified = true;
    }

    public void setIsInteractive(bool input) {
        sphere.isInteractive = input;
        ObjectisModified = true;
    }

    void Update() {
        if (ObjectisModified) {
            transform.localPosition = sphere.position;
            if (sphere.isInteractive)
                gameObject.AddComponent<Leap.Unity.Interaction.InteractionBehaviour>();
            else if (gameObject.GetComponent<Leap.Unity.Interaction.InteractionBehaviour>())
                Destroy(gameObject.GetComponent<Leap.Unity.Interaction.InteractionBehaviour>());
            ObjectisModified = false;
        }
    }
}
