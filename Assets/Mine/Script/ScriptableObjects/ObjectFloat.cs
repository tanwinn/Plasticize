﻿using System.Collections;

using System.Collections.Generic;

using UnityEngine;


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

    private void Start() {
        rb = GetComponent<Rigidbody>() as Rigidbody;
        if (rb == null) {
            Debug.LogWarning("ObjectFloat.cs component of " + this + " does not have a Rigidbody. Adding Rigidbody");
            gameObject.AddComponent<Rigidbody>();
        }
    }

    void FixedUpdate () {
        rb = GetComponent<Rigidbody>() as Rigidbody;

        forceFactor = 1.0f - ((transform.position.y - waterLevel) / floatThreshold);

		if (forceFactor > 0.0f) {

			floatForce = -Physics.gravity * rb.mass * (forceFactor - rb.velocity.y * waterDensity);

			floatForce += new Vector3 (0.0f, -downForce * rb.mass, 0.0f);

			rb.AddForceAtPosition (floatForce, transform.position);

		}

	}

}

