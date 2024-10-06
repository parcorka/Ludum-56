//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerInteract : MonoBehaviour
//{
//    public float interactRange = 4f;
//    // Update is called once per frame
//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.E))
//        {
//            IInteractable interactable = GetIntaractableObject();
//            if (interactable != null)
//            {
//                interactable.Interact(transform);
//            }
//        }
//    }

//    public IInteractable GetIntaractableObject()
//    {
//        List<IInteractable> interactableList = new List<IInteractable>();
//        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
//        foreach (Collider collider in colliderArray)
//        {
//            if(collider.TryGetComponent(out IInteractable interactable))
//            {
//                interactableList.Add(interactable);
//            }
//        }

//        IInteractable closestInteractable = null;
//        foreach (IInteractable interactable in interactableList) 
//        {
//            if (closestInteractable == null)
//            {
//                closestInteractable = interactable;
//            }
//            else
//            {
//                if(Vector3.Distance(transform.position, interactable.GetTransform().position) < Vector3.Distance(transform.position, closestInteractable.GetTransform().position))
//                {
//                    closestInteractable = interactable;
//                }
//            }
//        }
//        return closestInteractable;
//    }
//}
