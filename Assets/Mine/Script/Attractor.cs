using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Brackey's gravity simulation in Unity
// two gravitational objects depends on their masses and their distance

public class Attractor : MonoBehaviour {

    // make sure that the object that has this class has a rigid body
    // make rb public so that other Attractors can access it
    public Rigidbody rb;  // --> this type of variables are assigned through Unity, then you can grab thair attributes from the code

    // stuff, motions, actions that will be constantly updated depending on the fps
    // update fixed amount of time per sec
    private void FixedUpdate() {
        // Find all Attractor objects presented in the scene
        Attractor[] attractors = FindObjectsOfType<Attractor>();

        // for each is similar to how for (int i=0...) can only use within this scope
        foreach (Attractor attractor in attractors) {
            // make sure that the attractor isn't attracting itself
            if (attractor != this)
                Attract(attractor);
        }
    }

    void Attract (Attractor objToAttract) {
        // get the body of the other Attractor
        Rigidbody rbToAttract = objToAttract.rb;

        // get the distance between the two objects
        // Vector3 object works with positions, (x,y,z) coordinators
        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        //Newton's Law or sth
        float forceMagnitude = (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        // force are Vector3
        Vector3 force = direction.normalized * forceMagnitude;

        // aply the forc to the objects
        rb.AddForce(force);
    }
}
