using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XPO
{
    public class ControllerSwitch : MonoBehaviour
    {
        #region EVENTS

        public static event Action OnControllerMoving = delegate { };
        public static event Action OnCameraMoving = delegate { };

        #endregion

        [SerializeField] MouseLook cameraLook;
        [SerializeField] MouseLook controllerLook;
        [SerializeField] LineRenderer controllerPointer;

        private bool controllerOn;

        private void Start()
        {
            ToggleControllerLook(false);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                ToggleControllerLook(controllerOn);
            }
        }

        private void ToggleControllerLook(bool _controllerOn)
        {
            if (_controllerOn)
                OnControllerMoving();
            else
                OnCameraMoving();
            
            // adjust bool value first
            controllerOn = !_controllerOn;

            controllerLook.enabled = _controllerOn;
            cameraLook.enabled = !_controllerOn;
            controllerPointer.enabled = _controllerOn;
        }
    }

}