using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XPO
{
    public class MouseLock : MonoBehaviour
    {      
        void Start()
        {
            // Hide cursor while in-game
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }     
    }
}


