using Leap.Unity;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace SeniorIS.CrossPlatformInput {
    public class Gesture : MonoBehaviour {
        public Detector detector;
        public string axisName { set; get; }        // The name of the axis
        public float axisValue { set; get; }        // The value that the button has
        public float responseSpeed { set; get; }    // The speed at which the axis touch button responds
        public float returnToCentreSpeed { set; get; }  // The speed at which the button will return to its centre
        public CrossPlatformInputManager.VirtualButton vButton { set; get; }


        public Gesture(
            Detector detector,
            string axisName = "Horizontal",
            float axisValue = 1f,
            float responseSpeed = 3f, 
            float returnToCentreSpeed = 3f) {

            this.axisName = axisName;
            this.axisValue = axisValue;
            this.responseSpeed = responseSpeed;
            this.returnToCentreSpeed = returnToCentreSpeed;
            this.detector = detector;
        }

        void Update() {            
            if (this.axisValue > 1)
                this.axisValue = 1;
            else if (this.axisValue < -1)
                this.axisValue = -1;
        }

    }
}