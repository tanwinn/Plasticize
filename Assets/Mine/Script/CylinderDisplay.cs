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
        transform.localPosition = new Vector3(0f, 1f, 0f);
        if (cylinder.isInteractive)
            gameObject.AddComponent<Leap.Unity.Interaction.InteractionBehaviour>();
    }
}
