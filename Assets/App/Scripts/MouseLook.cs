using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XPO
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] float mouseSensitivity = 100F;
        [SerializeField] Transform playerBody;

        private float xRotation = 0F;

        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            // Looking up and down
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90F, 90F);
            //transform.localRotation = Quaternion.Euler(xRotation, 0F, 0F);
            
            if (playerBody != null)
            {
                // Looking + rotating left and right
                transform.localRotation = Quaternion.Euler(xRotation, 0F, 0F);
                playerBody.Rotate(Vector3.up * mouseX);
            }
            else
            {
                //var rotX = Input.GetAxis("Mouse X") * Mathf.Rad2Deg;

                //transform.localRotation = Quaternion.Euler(xRotation, transform.localRotation.y, transform.localRotation.z);


                // Rotate self if there is no body to rotate
                transform.Rotate(Vector3.up * mouseX);
                transform.Rotate(Vector3.right * -mouseY);

                //transform.Rotate((Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime), (Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime), 0, Space.World);
                //transform.Rotate((Input.GetAxis("Mouse X") * 5F * Time.deltaTime), 0, (Input.GetAxis("Mouse Y") * 5F * Time.deltaTime), Space.World);

                //transform.LookAt(Camera.main.ScreenToViewportPoint(transform.position));
            }
        }
    }
}