using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionSystem : MonoBehaviour
{
    // The object that the raycast is currently hitting
    public GameObject focusedObject;

    public GameObject pickupSlot;

    public float interactDistance;

    public bool holding;

    // This function is called every fixed framerate frame, if the MonoBhaviour is enabled
    private void FixedUpdate()
    {
        // if player is holding, return
        if (holding)
            return;

        // Compute the player's forward direction
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        // hit var to store our results
        RaycastHit hit;

        // ray originating from the camera
        Ray ray = new Ray(transform.position, fwd);

        // Conduct the raycast
        if (Physics.Raycast(ray, out hit))
        {
            focusedObject = hit.collider.gameObject;
        }
        else
        {
            focusedObject = null;
        }
    }

    public void OnInteract()
    {
        if (holding)
        {
            // Drop what we're holding
            focusedObject.transform.parent = null;
            focusedObject.GetComponent<Rigidbody>().isKinematic = false;
            holding = false;
        }
        else if (focusedObject.CompareTag("Interactable"))
        {
            // Pick the barrel up
            focusedObject.transform.parent = pickupSlot.transform;
            focusedObject.transform.position = pickupSlot.transform.position;
            focusedObject.GetComponent<Rigidbody>().isKinematic = true;
            holding = true;
        }
    }
}
