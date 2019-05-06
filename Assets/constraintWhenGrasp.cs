using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constraintWhenGrasp : MonoBehaviour {

    private InteractionBehaviour _intObj;
    private void OnEnable() {
        _intObj = GetComponent<InteractionBehaviour>();
        _intObj.OnGraspedMovement -= onGraspedMovement; // Prevent double-subscription.
        _intObj.OnGraspedMovement += onGraspedMovement;
    }
    private void OnDisable() {
        _intObj.OnGraspedMovement -= onGraspedMovement;
    }
    private void onGraspedMovement(Vector3 presolvedPos, Quaternion presolvedRot,
                                   Vector3 solvedPos, Quaternion solvedRot,
                                   List<InteractionController> graspingControllers) {
        // Project the vector of the motion of the object due to grasping along the world X axis.
        Vector3 movementDueToGrasp = solvedPos - presolvedPos;
        float yAxisMovement = movementDueToGrasp.y;
        // Move the object back to its position before the grasp solve this frame,
        // then add just its movement along the world Y axis.
        _intObj.rigidbody.position = presolvedPos;
        _intObj.rigidbody.position += Vector3.right * yAxisMovement;
    }
}
