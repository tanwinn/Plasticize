﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDisplay : MonoBehaviour {
    public Cube cube;
    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().material = cube.material;
        name = cube.name;
        transform.localScale = new Vector3(cube.size, cube.size, cube.size);
        if (cube.isInteractive)
            gameObject.AddComponent<Leap.Unity.Interaction.InteractionBehaviour>();
        else
            gameObject.AddComponent<Rigidbody>();
    }

    // Keeps track of the change for ome-time update
    private bool ObjectIsModified = false;

    public void setIsInteractive(bool input) {
        cube.isInteractive = input;
        ObjectIsModified = true;
    }

    void Update() {
        if (ObjectIsModified) {
            if (cube.isInteractive) {
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
