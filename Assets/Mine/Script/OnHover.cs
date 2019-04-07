using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;
using cakeslice;


public class OnHover : MonoBehaviour {
    InteractionBehaviour behaviorManager;

    public int hoveredColorIndex = 1;
    //public int graspedColorIndex = 2;

    private void Start() {
        behaviorManager = gameObject.GetComponent<InteractionBehaviour>();
        if (behaviorManager == null)
            gameObject.AddComponent<InteractionBehaviour>();
    }

    private void Outlined(int color) {
        if (gameObject.GetComponent<Outline>() == null)
            gameObject.AddComponent<Outline>();
        Outline script = gameObject.GetComponent<Outline>();
        script.color = color;

    }

    private void NonOutlined() {
        if (gameObject.GetComponent<Outline>() != null)
            Destroy(gameObject.GetComponent<Outline>());
    }


    private void FixedUpdate() {
        if (behaviorManager.isHovered) {
            Debug.Log("isHovered");
            Outlined(hoveredColorIndex);
        }
        //else if (behaviorManager.isGrasped) {
        //    Debug.Log("isGrasped");
        //    Outlined(graspedColorIndex);
        //}
        else {
            NonOutlined();
        }
    }
}
