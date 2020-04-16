using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XPO
{
    public class ControllerSwitch : MonoBehaviour
    {
        [SerializeField] MouseLook cameraLook;
        [SerializeField] MouseLook controllerLook;

        private bool controllerOn;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                ToggleControllerLook(controllerOn);
            }
        }

        private void ToggleControllerLook(bool _controllerOn)
        {                        
            controllerLook.enabled = !_controllerOn;
            cameraLook.enabled = _controllerOn;
            controllerOn = !_controllerOn;            
        }
    }

}