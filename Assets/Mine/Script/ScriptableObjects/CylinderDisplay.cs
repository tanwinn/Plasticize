using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderDisplay : MonoBehaviour {
    public Cylinder cylinder;
    // Keeps track of the change for ome-time update
    private bool ObjectisModified = false;

    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().material = cylinder.material;
        name = cylinder.name;
        transform.localScale = new Vector3(cylinder.width, cylinder.height, cylinder.width);
        transform.localPosition = cylinder.position;
        if (cylinder.isInteractive)
            gameObject.AddComponent<Leap.Unity.Interaction.InteractionBehaviour>();
    }

    public void setPosition(Vector3 input) {
        cylinder.position = input;
        ObjectisModified = true;
    }

    public void setIsInteractive(bool input) {
        cylinder.isInteractive = input;
        ObjectisModified = true;
    }

    void Update() {
        if (ObjectisModified) {
            transform.localPosition = cylinder.position;
            if (cylinder.isInteractive)
                gameObject.AddComponent<Leap.Unity.Interaction.InteractionBehaviour>();
            else if (gameObject.GetComponent<Leap.Unity.Interaction.InteractionBehaviour>())
                Destroy(gameObject.GetComponent<Leap.Unity.Interaction.InteractionBehaviour>());
            ObjectisModified = false;
        }
    }

}
