using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderDisplay : MonoBehaviour {
    public Cylinder cylinder;

    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().material = cylinder.material;
        name = cylinder.name;
        transform.localScale = new Vector3(cylinder.width, cylinder.height, cylinder.width);
        if (cylinder.isInteractive)
            gameObject.AddComponent<Leap.Unity.Interaction.InteractionBehaviour>();
        else
            gameObject.AddComponent<Rigidbody>();
    }
    
    // Keeps track of the change for ome-time update
    private bool ObjectIsModified = false;
    public void setIsInteractive(bool input) {
        cylinder.isInteractive = input;
        ObjectIsModified = true;
    }

    
    void Update() {
        if (ObjectIsModified) {
            if (cylinder.isInteractive) {
                gameObject.AddComponent<Leap.Unity.Interaction.InteractionBehaviour>();
            }
            else if (gameObject.GetComponent<Leap.Unity.Interaction.InteractionBehaviour>()) {
                //Debug.Log("Destroy Interaction Behaviour");
                Destroy(gameObject.GetComponent<Leap.Unity.Interaction.InteractionBehaviour>());
                gameObject.AddComponent<Rigidbody>();
            }
            ObjectIsModified = false;
        }
    }

}
