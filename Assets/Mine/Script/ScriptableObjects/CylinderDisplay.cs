using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CylinderDisplay : DisplayScript {
    //public Shape scriptObject;
    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Renderer>().material = scriptObject.material;
        name = scriptObject.name;
        transform.localScale = new Vector3(scriptObject.size, scriptObject.size*2, scriptObject.size);
        if (scriptObject.isInteractive)
            gameObject.AddComponent<Leap.Unity.Interaction.InteractionBehaviour>();   
    }

    #region Deprecated
    // Keeps track of the change for ome-time update
    [System.Obsolete]
    private bool ObjectIsModified = false;
    [System.Obsolete]
    public void setIsInteractive(bool input) {
        scriptObject.isInteractive = input;
        ObjectIsModified = true;
    }

    [System.Obsolete]
    void _Update() {
        if (ObjectIsModified) {
            if (scriptObject.isInteractive) {
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
    #endregion

}
