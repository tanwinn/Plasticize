//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;
//using UnityEngine.EventSystems;
//using System;
////using Leap;
//using UnityStandardAssets.Characters;
////using GestureManager = List<Detector>;

////namespace UnityStandardAssets.Characters.FirstPerson { 
//namespace SeniorIS {
//    public class LeapInput : MonoBehaviour {
//        // example: JoyStick.cs
//        // virtual Input is the abstraction layer for multiple platforms such as windows, macOs, joysticks, and phone devices system control to map with one 
//        // control system in Unity
//        // VirtualButton object: e.g. up, down, left, right arrow keys, etc.
//        // VirtualAxis: Horizontol = left(-1) + right(+1)
//        PointerEventData EventData;

//        // public static GameObject GestureManager;
        
//        public static GestureManager GestureManager;

//        //public static GestureManager 
//        static VirtualButton verticalPositiveButton;
//        static VirtualButton verticalNegativeButton;
//        static VirtualButton horizontalPositiveButton;
//        static VirtualButton horizontalNegativeButton;

//        public enum AxisOption {
//            // Options for which axes to use
//            Both, // Use both
//            OnlyHorizontal, // Only horizontal
//            OnlyVertical // Only vertical
//        }

//        public AxisOption axesToUse = AxisOption.Both; // The options for the axes that the still will use
//        public string horizontalAxisName = "Horizontal"; // The name given to the horizontal axis for the cross platform input
//        public string verticalAxisName = "Vertical"; // The name given to the vertical axis for the cross platform input

//        bool m_UseX; // Toggle for using the x axis
//        bool m_UseY; // Toggle for using the Y axis
//        CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis; // Reference to the joystick in the cross platform input
//        CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis; // Reference to the joystick in the cross platform input

//        // https://answers.unity.com/questions/217941/onenable-awake-start-order.html
//        void OnEnable() {
//            // set axes to use
//            m_UseX = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyHorizontal);
//            m_UseY = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyVertical);

//            CreateVirtualButton(GestureManager);
//        }

//        void DataProcessing(PointerEventData EventData) {
//            EventData.position = new Vector2(4, 4);
//            Debug.Log(EventData.IsPointerMoving());
//        }

//        public void OnPressed(PointerEventData EventData, VirtualButton button) {
//            Debug.Log("before OnPointerDown: " + CrossPlatformInputManager.GetAxis(button.axisName));
//            button.OnPointerDown(EventData);
//            Debug.Log("After OnPointerDown: " + CrossPlatformInputManager.GetAxis(button.axisName));
//        }


//        void CreateVirtualButton(GestureManager GestureManager) {
//            for (Detector gesture in GestureManager) {
//                // registerButton
//                // RegisterVirtualButton(gesture.name, gesture.matchWith, gesture.axisName);



//            }
//            //CrossPlatformInputManager.VirtualButton LeapGesture = new CrossPlatformInputManager.VirtualButton("forwardGesture", false);
//            //CrossPlatformInputManager.RegisterVirtualButton(LeapGesture);
            
//            // // Horizontal
//            // if (m_UseX) {
//            //     horizontalPositiveButton = new VirtualButton(horizontalAxisName, 1);
//            //     horizontalNegativeButton = new VirtualButton(horizontalAxisName, -1);
//            // }
//            // // Vertical
//            // if (m_UseY) {
//            //     verticalPositiveButton = new VirtualButton(verticalAxisName, 1);
//            //     verticalNegativeButton = new VirtualButton(verticalAxisName, -1);
//            // }
            
//    }

//        void CreateVirtualAxes() {
//            // create new axes based on axes to use
//            if (m_UseX) {
//                m_HorizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(horizontalAxisName);
//                CrossPlatformInputManager.RegisterVirtualAxis(m_HorizontalVirtualAxis);
//            }
//            if (m_UseY) {
//                m_VerticalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(verticalAxisName);
//                CrossPlatformInputManager.RegisterVirtualAxis(m_VerticalVirtualAxis);
//            }
//        }

//        // Time.deltaTime * Sensitivity when engaged
//        // Time.deltaTime* Gravity when not engaged/released

//        void UpdateAxes() {
            
//        }

//        void OnDisable() {
//            // remove the gesture from the cross platform input
//            if (m_UseX) {
//                m_HorizontalVirtualAxis.Remove();
//            }
//            if (m_UseY) {
//                m_VerticalVirtualAxis.Remove();
//            }
//        }
        
//        public float GetAxis(string nameAxis) {
//            return 0.4f;
//        }
//    }
//}
