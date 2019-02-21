using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointAutoRotate : MonoBehaviour {
    public float rotateSpeed = 10f;

    void Update() {
        // rotate around y-axis
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
