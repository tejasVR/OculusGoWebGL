using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace XPO
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] Image cursor;
        [SerializeField] Image hudBorder;
        [SerializeField] TextMeshProUGUI hudText;
        [SerializeField] TextMeshProUGUI hudInstructions;

        [SerializeField] Color cameraEnabledColor;
        [SerializeField] Color controllerEnabledColor;
        private void OnEnable()
        {
            ControllerSwitch.OnCameraMoving += CameraEnabled;
            ControllerSwitch.OnControllerMoving += ControllerEnabled;
        }

        private void OnDisable()
        {
            ControllerSwitch.OnCameraMoving -= CameraEnabled;
            ControllerSwitch.OnControllerMoving -= ControllerEnabled;
        }

        private void Start()
        {
            CameraEnabled();
        }

        private void CameraEnabled()
        {
            hudText.text = "<b>Camera</b> Control Enabled";

            cursor.enabled = true;
            hudBorder.color = cameraEnabledColor;
            hudText.color = cameraEnabledColor;
            hudInstructions.color = cameraEnabledColor;
        }

        private void ControllerEnabled()
        {
            hudText.text = "<b>Controller</b> Control Enabled";

            cursor.enabled = false;
            hudBorder.color = controllerEnabledColor;
            hudText.color = controllerEnabledColor;
            hudInstructions.color = controllerEnabledColor;
        }

    }
}


