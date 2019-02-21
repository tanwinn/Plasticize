// SourceCode: https://www.youtube.com/watch?v=FtcdkfvrQv0﻿

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectFloat : MonoBehaviour {
    #region Attributes
    public float waterLevel = .85f;

	public float floatThreshold = 2f;

	public float waterDensity = .8f;

	public float downForce = .5f;

	private float forceFactor;

	private Vector3 floatForce;

    private static Rigidbody rb;
    #endregion

    [System.Obsolete]
    private void _Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        if (rb == null) {
            Debug.LogWarning("ObjectFloat.cs component of " + this + " does not have a Rigidbody. Adding Rigidbody");
            gameObject.AddComponent<Rigidbody>();
        }
    }

    void FixedUpdate () {
        rb = gameObject.GetComponent<Rigidbody>();

        forceFactor = 1.0f - ((transform.position.y - waterLevel) / floatThreshold);

		if (forceFactor > 0.0f) {
			floatForce = -Physics.gravity * rb.mass * (forceFactor - rb.velocity.y * waterDensity);
			floatForce += new Vector3 (0.0f, -downForce * rb.mass, 0.0f);
			rb.AddForceAtPosition (floatForce, transform.position);
		}
	}
}

