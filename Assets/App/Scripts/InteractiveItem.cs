using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using XRCORE;

namespace XRCORE.VR.INTERACTIVE
{
    // A script that attaches to an VR interactive object

    //[RequireComponent(typeof(Collider))]
    public class InteractiveItem : MonoBehaviour
    {
        public event Action ItemHoverEnterCallback;
        public event Action ItemHoverStayCallback;
        public event Action ItemHoverExitCallback;
        public event Action ItemUsedCallback;
        public event Action ItemUnusedCallback;

        public bool shouldDebug;

        [Space(7)]
        public UnityEvent hoverEnter;
        public UnityEvent hoverStay;
        public UnityEvent hoverExit;
        public UnityEvent used;
        public UnityEvent unused;

        public virtual void OnItemHoverEnter()
        {
            ItemHoverEnterCallback?.Invoke();
            hoverEnter.Invoke();

            if (shouldDebug)
                Debug.Log(gameObject.name + " is calling Hover Enter");
        }

        public virtual void OnItemHoverStay()
        {
            ItemHoverStayCallback?.Invoke();
            hoverStay.Invoke();

            if (shouldDebug)
                Debug.Log(gameObject.name + " is calling Hover Stay");
        }

        public virtual void OnItemHoverExit()
        {
            ItemHoverExitCallback?.Invoke();
            hoverExit.Invoke();

            if (shouldDebug)
                Debug.Log(gameObject.name + " is calling Hover Exit");
        }

        public virtual void OnItemUsed()
        {
            ItemUsedCallback?.Invoke();
            used.Invoke();

            if (shouldDebug)
                Debug.Log(gameObject.name + " is calling Item Used");
        }

        public virtual void OnItemUnused()
        {
            ItemUnusedCallback?.Invoke();
            unused.Invoke();

            if (shouldDebug)
                Debug.Log(gameObject.name + " is calling Item Unused");
        }
    }
}


