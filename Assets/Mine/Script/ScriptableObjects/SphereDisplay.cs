using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDisplay : MonoBehaviour {
    public Sphere sphere;
    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().material = sphere.material;
        name = sphere.name;
        transform.localScale = new Vector3(sphere.size, sphere.size, sphere.size);
        // default for now, when generate, can randomize position and rotation
        transform.localPosition = new Vector3(0f, 1f, 0f);
        if (sphere.isInteractive)
            gameObject.AddComponent<Leap.Unity.Interaction.InteractionBehaviour>();
    }
}
