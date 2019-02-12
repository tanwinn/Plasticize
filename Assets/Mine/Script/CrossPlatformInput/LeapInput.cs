using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.EventSystems;
using System;

//using UnityStandardAssets.Characters;
//namespace Assets.Mine.Script.CrossPlatformInput { 
//namespace UnityStandardAssets.Characters.FirstPerson { 
namespace SeniorIS.CrossPlatformInput {
    public class LeapInput : MonoBehaviour {
        // example: JoyStick.cs
        // virtual Input is the abstraction layer for multiple platforms such as windows, macOs, joysticks, and phone devices system control to map with one 
        // control system in Unity
        // VirtualButton object: e.g. up, down, left, right arrow keys, etc.
        // VirtualAxis: Horizontol = left(-1) + right(+1)
        public GameObject LeapInputTesting;
        public List<Gesture> GestureManager;
        //public static List<Detector> DetectorManager;
        //List<CrossPlatformInputManager.VirtualButton> VirtualButtonManager;

        void CreateVirtualButtons() {
            //VirtualButtonManager = new List<CrossPlatformInputManager.VirtualButton>();
            foreach (Gesture gesture in GestureManager) {
                CrossPlatformInputManager.VirtualButton vButton = new CrossPlatformInputManager.VirtualButton(gesture.detector.name, gesture.axisName, gesture.axisValue);
                gesture.vButton = vButton;
                vButton.returnToCentreSpeed = gesture.returnToCentreSpeed;
                vButton.responseSpeed = gesture.responseSpeed;
                CrossPlatformInputManager.RegisterVirtualButton(vButton);
            }
        }

        void CreateVirtualAxes() {
                foreach (Gesture gesture in GestureManager) {
                    if (CrossPlatformInputManager.AxisExists(gesture.axisName)) {
                        CrossPlatformInputManager.VirtualAxis vAxis = new CrossPlatformInputManager.VirtualAxis(gesture.axisName);
                    CrossPlatformInputManager.RegisterVirtualAxis(vAxis);
                }
            }
        }
        

        void FixedUpdate() {
            foreach (Gesture gesture in GestureManager) {
                CrossPlatformInputManager.VirtualButton currentButton = gesture.vButton;
                if (gesture.detector.name == "deactivate") {
                    currentButton.Released();
                    UpdateAxisOfButton(currentButton, false);
                }
                else {
                    currentButton.Pressed();
                    UpdateAxisOfButton(currentButton, true);
                }
                
            }
        }
        // https://answers.unity.com/questions/217941/onenable-awake-start-order.html
        void OnEnable() {
            GestureManager = LeapInputTesting.GetComponent<List<Gesture>>();
            CreateVirtualButtons();
            CreateVirtualAxes();
        }

        
        void UpdateAxisOfButton(CrossPlatformInputManager.VirtualButton button, bool isPressed) {
            CrossPlatformInputManager.VirtualAxis currentAxis = CrossPlatformInputManager.VirtualAxisReference(button.axisName);
            float value;
            if (isPressed) {
                value = Mathf.MoveTowards(currentAxis.GetValue, button.axisValue, button.responseSpeed * Time.deltaTime);
            }
            else {
                value = Mathf.MoveTowards(currentAxis.GetValue, 0, button.returnToCentreSpeed * Time.deltaTime);
            }
            currentAxis.Update(value);
        }

        void OnDisable() {
            foreach (Gesture gesture in GestureManager) {
                CrossPlatformInputManager.VirtualAxis currentAxis = CrossPlatformInputManager.VirtualAxisReference(gesture.axisName);
                currentAxis.Remove();
                gesture.vButton.Remove();
            }
        }
    }
}
