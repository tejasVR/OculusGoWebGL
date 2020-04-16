using System;
using UnityEngine;
using XRCORE.VR.INTERACTIVE;

namespace XPO
{
    public class HoveredObject
    {
        public RaycastHit raycastHit;
        public GameObject obj;

        public HoveredObject(RaycastHit _raycastHit, GameObject _gameObject)
        {
            raycastHit = _raycastHit;
            obj = _gameObject;
        }
    }

    public class ControllerInteraction : MonoBehaviour
    {
        #region EVENTS

        public event Action OnHoverEnter = delegate { };
        public event Action OnHoverExit = delegate { };

        #endregion

        public LayerMask interactiveLayer;

        private InteractiveItem interactiveItem;

        private void Update()
        {
            PointerInteraction();

            if (Input.GetMouseButtonDown(0))
            {
                PointerSelect();
            }
        }

        private void PointerInteraction()
        {
            HoveredObject interactiveObject = RaycastAgainstInteractiveLayer();

            if (interactiveObject != null)
            {
                if (interactiveItem != interactiveObject.obj.GetComponent<InteractiveItem>())
                    HoverEnter(interactiveObject.obj.GetComponent<InteractiveItem>());
                else
                    HoverStay();
            }
            else
            {
                HoverExit();
            }

            //Ray ray = new Ray(transform.position, transform.forward);

            //if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            //{
               
            //}
         
        }

        private void PointerSelect()
        {
            RaycastHit rayHit = RaycastAgainstLayer(transform.position, transform.forward, interactiveLayer);

            if (rayHit.collider != null)
            {
                var go = rayHit.collider.gameObject;

                if (go.GetComponent<InteractiveItem>())
                {
                    UseItem(go.GetComponent<InteractiveItem>());
                }
            }
        }

        private void HoverEnter(InteractiveItem _interactiveItem)
        {
            interactiveItem = _interactiveItem;
            interactiveItem.OnItemHoverEnter();

            OnHoverEnter();
        }

        private void HoverStay()
        {
            //interactiveItem.OnItemHoverStay();
        }

        private void HoverExit()
        {
            if (interactiveItem != null)
            {
                interactiveItem.OnItemHoverExit();

                interactiveItem = null;

                OnHoverExit();
            }
        }

        private void UseItem(InteractiveItem _interactiveItem)
        {
            interactiveItem = _interactiveItem;
            interactiveItem.OnItemUsed();
        }

        private HoveredObject RaycastAgainstInteractiveLayer()
        {
            RaycastHit interactiveUIHit = RaycastAgainstLayer(transform.position, transform.forward, interactiveLayer);

            if (interactiveUIHit.collider != null)
            {
                HoveredObject hoveredObject = new HoveredObject(interactiveUIHit, interactiveUIHit.collider.gameObject);
                return hoveredObject;
            }
          
            return null;
        }

        private RaycastHit RaycastAgainstLayer(Vector3 _origin, Vector3 _direction, LayerMask _layer)
        {
            Ray ray = new Ray(_origin, _direction);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layer))
            {
                return hit;
            }

            return hit;
        }
    }
}