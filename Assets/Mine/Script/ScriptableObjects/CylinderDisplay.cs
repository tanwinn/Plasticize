using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderDisplay : DisplayScript {
    //public Shape scriptObject;
    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().material = scriptObject.material;
        name = scriptObject.name;
        transform.localScale = new Vector3(scriptObject.size, scriptObject.size*2, scriptObject.size);

        Rigidbody rb = gameObject.AddComponent<Rigidbody>() as Rigidbody;

        if (scriptObject.isInteractive)
            gameObject.AddComponent<Leap.Unity.Interaction.InteractionBehaviour>();   
    }
    
    //// Keeps track of the change for ome-time update
    //private bool ObjectIsModified = false;
    //public void setIsInteractive(bool input) {
    //    scriptObject.isInteractive = input;
    //    ObjectIsModified = true;
    //}

    
    //void Update() {
    //    if (ObjectIsModified) {
    //        if (scriptObject.isInteractive) {
    //            gameObject.AddComponent<Leap.Unity.Interaction.InteractionBehaviour>();
    //        }
    //        else if (gameObject.GetComponent<Leap.Unity.Interaction.InteractionBehaviour>()) {
    //            //Debug.Log("Destroy Interaction Behaviour");
    //            Destroy(gameObject.GetComponent<Leap.Unity.Interaction.InteractionBehaviour>());
    //            gameObject.AddComponent<Rigidbody>();
    //        }
    //        ObjectIsModified = false;
    //    }
    //}

}
